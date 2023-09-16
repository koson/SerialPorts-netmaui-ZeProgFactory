# SerialPorts and MAUI

## test with /dev/tty.usbserial-FTF91Q27
|                     | List | Test |  |                      |      
|---------------------|------|------|--|----------------------|
| .CMD PC ARM         |  KO  |      |  | "//s" missing driver |
| .CMD PC x64         |  OK  |  OK  |  |                      |
| .CMD Mac ARM        |      |      |  |                      |
| .CMD Mac x64        |      |      |  |                      |
| .Maui PC ARM        |  OK  |  KO  |  |                      |
| .Maui PC x64        |  OK  |  OK  |  |                      |
| .Maui Mac ARM       |  OK  |  KO  |  | "lib"                |
| .Maui Mac x64       |      |      |  |                      |
|                     |      |      |  |                      |
| .CMD PC ARM & Dll   |      |      |  |                      |
| .CMD PC x64 & Dll   |  OK  |  OK  |  |                      |
| .CMD Mac ARM & Dll  |      |      |  |                      |
| .CMD Mac x64 & Dll  |      |      |  |                      |
| .Maui PC ARM & Dll  |      |      |  |                      |
| .Maui PC x64 & Dll  |      |      |  |                      |
| .Maui Mac ARM & Dll |      |      |  |                      |
| .Maui Mac x64 & Dll |      |      |  |                      |
   
     
## clues to solve this issue ...
###  MacOS
[Serial Port Programming in Swift for MacOS](https://www.mac-usb-serial.com/docs/tutorials/serial-port-programming-swift-mac-os-x.html)

[SwiftSerial](https://github.com/yeokm1/SwiftSerial)   
A Swift Linux and Mac library for reading and writing to serial ports. This library has been tested to work on macOS ...   
   
[Accessing Serial Port on different platforms](https://github.com/dotnet/maui/discussions/4526)  
Since .NET 6 was supposed to bring the cross-platform API under one hood, I would like to ask whether SerialPort was also considered for that. When moving from a Windows only app on WPF to .NET Maui I was kind of expecting to just use System.IO.Ports.SerialPort for all my serial port needs, however it seems to not be the case.  
   
[ORSSerialPort](https://github.com/armadsen/ORSSerialPort)   
ORSSerialPort is an easy-to-use Objective-C serial port library for macOS ...   
   

### Android
[UsbSerialForAndroid](https://github.com/Jignesh-Darji/xamarin-usb-serial-for-android-2019)  


### Linux  
[Using embedded GPIO UART serial port with .NET Core 2.0 on a Raspberry PI 3 running Linux](https://github.com/Ellerbach/serialapp)

