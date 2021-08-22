using hymax.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace hymax.Services.Core
{
    class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
