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
         var portnames = ZPF.COMHelper.SerialPortGetPortNames();

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

   void btnTest_Clicked(System.Object sender, System.EventArgs e)
   {
      string port = "COM3";
      string buffer = "Holla die Waldfee";

      if ( !ZPF.COMHelper.Write2SerialPort( port,  buffer))
      {
         label.Text += ZPF.COMHelper.LastMessage;
      }
   }

}

