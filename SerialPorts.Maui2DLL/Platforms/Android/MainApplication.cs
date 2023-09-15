using Android.App;
using Android.Runtime;

namespace SerialPorts.Maui2DLL;

[Application]
public class MainApplication : MauiApplication
{
   public MainApplication(IntPtr handle, JniHandleOwnership ownership)
      : base(handle, ownership)
   {
   }

   protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

