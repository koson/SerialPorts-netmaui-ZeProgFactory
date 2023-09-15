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

[Serial Port Programming in Swift for MacOS](https://www.mac-usb-serial.com/docs/tutorials/serial-port-programming-swift-mac-os-x.html)

[SwiftSerial](https://github.com/yeokm1/SwiftSerial)   
A Swift Linux and Mac library for reading and writing to serial ports. This library has been tested to work on macOS ...   


