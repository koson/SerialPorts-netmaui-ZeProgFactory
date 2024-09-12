using System.Diagnostics;
using System.IO.Ports;

namespace SerialPorts.MAUI;

public partial class MainPage : ContentPage
{
   int baudrate;
   bool[] status = new bool[64];
   public MainPage()
   {
      InitializeComponent();

      // - - -  - - -

      btnRefresh_Clicked(null, null);
      pickerSpeed.Items.Clear();
      pickerSpeed.Items.Add("9600");
      pickerSpeed.Items.Add("19200");
      pickerSpeed.Items.Add("115200");
      pickerSpeed.SelectedIndexChanged += (sender, args) =>
      {
         int.TryParse(pickerSpeed.SelectedItem.ToString(), out baudrate);
         ZPF.COMHelper._baudRate = baudrate;
         Debug.WriteLine($"pickerSpeed = {ZPF.COMHelper._baudRate}");
      };
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
      string buffer = "*idn?" + Environment.NewLine;

      if (!ZPF.COMHelper.Write2SerialPort(port, buffer))
      {
         label.Text += port + Environment.NewLine + ZPF.COMHelper.LastMessage + Environment.NewLine;
      }
   }
   void OnButtonClicked(object sender, EventArgs args)
   {
      int buttonNumber;
      Debug.WriteLine((sender as Button).Text);
      int.TryParse((sender as Button).Text, out buttonNumber);
      status[buttonNumber - 1] = !status[buttonNumber - 1];
      string port = picker.SelectedItem as string;
      if (status[buttonNumber - 1] == true)
      {
         (sender as Button).BackgroundColor = Colors.LightGreen;
         (sender as Button).TextColor = Colors.Black;
         string buffer = "dout" + buttonNumber.ToString() + ":val1" + Environment.NewLine;
         if (ZPF.COMHelper._IsInitSerialPort == true)
            ZPF.COMHelper.Write2SerialPort(port, buffer);
      }
      else
      {
         (sender as Button).BackgroundColor = Colors.DarkGreen;
         (sender as Button).TextColor = Colors.White;
         string buffer = "dout" + buttonNumber.ToString() + ":val0" + Environment.NewLine;
         if (ZPF.COMHelper._IsInitSerialPort == true)
            ZPF.COMHelper.Write2SerialPort(port, buffer);

      }
   }
}

