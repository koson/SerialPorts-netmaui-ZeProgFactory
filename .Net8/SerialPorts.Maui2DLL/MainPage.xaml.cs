namespace SerialPorts.Maui2DLL;

public partial class MainPage : ContentPage
{
   public MainPage()
   {
      InitializeComponent();

      // - - -  - - -

      ListPorts();
      picker.ItemsSource = ZPF.COMHelper.SerialPortGetPortNames(DeviceInfo.Platform == DevicePlatform.MacCatalyst).ToList();
   }

   void btnRefresh_Clicked(System.Object sender, System.EventArgs e)
   {
      ListPorts();
      picker.ItemsSource = ZPF.COMHelper.SerialPortGetPortNames(DeviceInfo.Platform == DevicePlatform.MacCatalyst).ToList();
   }

   private void ListPorts()
   {
      string st = "";

      try
      {
         var portnames = ZPF.COMHelper.SerialPortGetPortNames(DeviceInfo.Platform == DevicePlatform.MacCatalyst);

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

      label.Text = st + Environment.NewLine;
   }

   void btnTest_Clicked(System.Object sender, System.EventArgs e)
   {
      string port = picker.SelectedItem as string;
      string buffer = "Holla die Waldfee";

      if (!ZPF.COMHelper.Write2SerialPort(port, buffer))
      {
         label.Text += port + Environment.NewLine + ZPF.COMHelper.LastMessage + Environment.NewLine;
      }
   }

}


