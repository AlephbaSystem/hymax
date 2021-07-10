using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace hymax.Services
{
    class IconServer
    {

        public static FontImageSource GetResource(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value))
            {
                return (FontImageSource)value;
            }

            throw new InvalidOperationException($"key {key} not found in the resource dictionary");
        }
    }
}