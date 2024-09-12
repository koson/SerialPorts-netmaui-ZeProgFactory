using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;

namespace ZPF;

public static class COMHelper
{
   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -

   public static IEnumerable<string> SerialPortGetPortNames(bool fromFileSystem = false)
   {
      // if (DeviceInfo.Platform == DevicePlatform.MacCatalyst)
      if (fromFileSystem)
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

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

   public static bool _IsInitSerialPort { get; private set; }
   public static string LastMessage { get; private set; }

   private static SerialPort _SerialPort;
   public static int _baudRate { get; set; }

   public static bool Write2SerialPort(string port,  string buffer)
   {
      LastMessage = "";

      if (!_IsInitSerialPort)
      {
         _IsInitSerialPort = InitSerialPort(port);
      };

      if (_IsInitSerialPort)
      {
         return SendData(buffer);
      }
      else
      {
         return false;
      };
   }

   public static bool InitSerialPort(string port)
   {
      _SerialPort = new SerialPort(port, _baudRate, Parity.None, 8, StopBits.One)
      {
         Handshake = Handshake.None,
         ReadTimeout = 0,
         WriteTimeout = 1000,
      };

      _SerialPort.ErrorReceived += _SerialPort_ErrorReceived;
      _SerialPort.DataReceived += SerialPort_DataReceived;

      try
      {
         _SerialPort.Open();
      }
      catch (Exception ex)
      {
         LastMessage = ex.Message;
         Debug.WriteLine(ex.Message);
         return false;
      };

      return true;
   }

   public static bool CloseSerialPort(string port)
   {
      try
      {
         if (_SerialPort != null) _SerialPort.Close();
         _IsInitSerialPort = false;
      }
      catch (Exception ex)
      {
         LastMessage = ex.Message;
         Debug.WriteLine(ex.Message);
         return false;
      };

      return true;
   }

   private static void _SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
   {
      Debug.WriteLine($"SerialPort_ErrorReceived: [{e.ToString()}]");
   }

   private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
   {
      Debug.WriteLine($"SerialPort_DataReceived: {(sender as SerialPort).ReadExisting()})]");
   }

   public static bool SendData(string Buffer)
   {
      try
      {
         if (!_SerialPort.IsOpen)
            _SerialPort.Open();

         //Buffer.Dump();

         byte[] array = Encoding.UTF8.GetBytes(Buffer);

         _SerialPort.Write(array, 0, array.Length);
      }
      catch (Exception ex)
      {
         LastMessage = ex.Message;
         Debug.WriteLine(ex.Message);
         return false;
      };

      return true;
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 
}
