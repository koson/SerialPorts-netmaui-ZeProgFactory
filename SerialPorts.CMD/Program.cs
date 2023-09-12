// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.IO.Ports;
using ZPF;

namespace SerialPorts;

class Program
{
   /* default ports

0 /dev/tty.BTHIFIAUDIO
1 /dev/tty.Bluetooth-Incoming-Port
2 /dev/cu.BTHIFIAUDIO
3 /dev/cu.Bluetooth-Incoming-Port

   */

   /* with 'USB to serial converter' 

0 /dev/tty.BTHIFIAUDIO
1 /dev/tty.Bluetooth-Incoming-Port
2 /dev/tty.usbserial-FTF91Q27
3 /dev/cu.BTHIFIAUDIO
4 /dev/cu.Bluetooth-Incoming-Port
5 /dev/cu.usbserial-FTF91Q27

   */

   static void Main(string[] args)
   {
      if (args.Count() == 0)
      {
         ShowHelper();
         ListPorts();
      }
      else if (args.Count() == 1)
      {
         ShowHelper();

         var portnames = SerialPort.GetPortNames();
         var ind = int.Parse(args[0]);
         var port = portnames[ind];

         COMHelper.Write2SerialPort(port, "Holla die Waldfee!");
         Console.WriteLine(COMHelper.LastMessage);
      }
      else
      {

      };

      if (Debugger.IsAttached)
      {
         Console.ReadKey();
      };
   }

   private static void ListPorts()
   {
       var portnames = SerialPort.GetPortNames();

      if (portnames.Count() == 0)
      {
         Console.WriteLine($"No serial port found ...");
      }
      else
      {
         int ind = 0;
         foreach (var s in portnames)
         {
            Console.WriteLine($"{ind} {s}");
            ind++;
         };
      };

      Console.WriteLine();
   }

   private static void ShowHelper()
   {
      Console.WriteLine();
      Console.WriteLine("SerialPorts - V 0.98");
      Console.WriteLine();
   }
}
