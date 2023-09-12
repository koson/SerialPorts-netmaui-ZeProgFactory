# SerialPorts

## test with /dev/tty.usbserial-FTF91Q27
|               | List | Test |  |                           |      
| .CMD ARM      |  KO  |  KO  |  | missing driver            |
| .CMD x64      |  OK  |  OK  |  |                           |
| .Maui PC ARM  |  OK  |  KO  |  |                           |
| .Maui PC x64  |  OK  |  OK  |  |                           |
| .Maui Mac ARM |  OK  |  KO  |  | libSystem.IO.Ports.Native |
| .Maui Mac x64 |      |      |  |                           |
