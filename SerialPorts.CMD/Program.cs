// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.IO.Ports;

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

        int ind = 0;
        foreach (var s in portnames)
        {
            Console.WriteLine($"{ind} {s}");
            ind++;
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
