using System.IO.Ports;

namespace SerialPorts.MAUI;

public partial class MainPage : ContentPage
{

   public MainPage()
   {
      InitializeComponent();

      // - - -  - - -

      ListPorts();
   }

   void btnRefresh_Clicked(System.Object sender, System.EventArgs e)
   {
      ListPorts();
   }

   private void ListPorts()
   {
      string st = "";

      try
      {
         var portnames = SerialPortGetPortNames();

         int ind = 0;
         foreach (var s in portnames)
         {
            st += $"{ind} {s}" + Environment.NewLine;
            ind++;
         };
      }
      catch (Exception ex)
      {
         st = ex.ToString();
      };

      label.Text = st;
   }

   private IEnumerable<string> SerialPortGetPortNames()
   {
      if (DeviceInfo.Platform == DevicePlatform.MacCatalyst)
      {
         List<string> list = new List<string>();

         {
            string[] files = Directory.GetFiles("/dev", "tty.*");
            foreach (string text in files)
            {
               if (text.StartsWith("/dev/tty.", StringComparison.Ordinal))
               {
                  list.Add(text);
               }
            }
         }

         {
            string[] files = Directory.GetFiles("/dev", "cu.*");
            foreach (string text in files)
            {
               if (text.StartsWith("/dev/cu.", StringComparison.Ordinal))
               {
                  list.Add(text);
               }
            }
         }

         return list.ToArray();
      }
      else
      {
         return SerialPort.GetPortNames();
      };


   }
}


