using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace hymax.Services
{
    class ColorServer
    {
        public static Color GetResource(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value))
            {
                return (Color)value;
            }

            throw new InvalidOperationException($"key {key} not found in the resource dictionary");
        }
    }
}
