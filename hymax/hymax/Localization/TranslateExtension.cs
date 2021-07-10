using hymax.Services;
using System;
using System.Globalization;
using System.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hymax.Localization
{
    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private static Type ResourceType; 

        private readonly CultureInfo _cultureInfo = null;

        private ResourceManager _resourceManager;

        public TranslateExtension()
        { 
            switch (Settings.Language)
            {
                case "EN":
                    ResourceType = typeof(AppResourcesEN);
                    break;
                case "FA":
                    ResourceType = typeof(AppResourcesFA);
                    break;
                default:
                    ResourceType = typeof(AppResourcesFA);
                    break;
            } 
            _cultureInfo = new CultureInfo(Settings.Language);
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return string.Empty;
            }

            if (_resourceManager == null)
            {
                _resourceManager = new ResourceManager(ResourceType);
            }

            var translation = _resourceManager.GetString(Text, _cultureInfo);
            if (translation == null)
            {
#if RELEASE
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#else
                throw new InvalidOperationException(
                    $"Key '{Text}' was not found in resources '{ResourceType.Name}' for culture '{_cultureInfo.Name}'.");
#endif
            }

            return translation;
        }
    }
}