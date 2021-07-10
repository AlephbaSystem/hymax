using hymax.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace hymax.Localization
{
    abstract class Localizations
    {
        public AppResourcesEN English() { return new AppResourcesEN(); }
        public AppResourcesFA Farsi() { return new AppResourcesFA(); } 
        public static System.Resources.ResourceManager GetResource()
        {
            switch (Settings.Language)
            {
                case "EN":
                    return AppResourcesEN.ResourceManager; 
                case "FA":
                    return AppResourcesFA.ResourceManager; 
                default:
                    return AppResourcesFA.ResourceManager; 
            } 
        }
    }
}
