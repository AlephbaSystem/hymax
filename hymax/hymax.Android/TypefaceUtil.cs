using Android.Content;
using Android.Graphics;
using Java.Lang;

namespace hymax.Droid
{
   public class TypefaceUtil
    {
        /**
       * Using reflection to override default typeface
       * NOTICE: DO NOT FORGET TO SET TYPEFACE FOR APP THEME AS DEFAULT TYPEFACE WHICH WILL BE OVERRIDDEN
       * @param context to work with assets
       * @param defaultFontNameToOverride for example "monospace"
       * @param customFontFileNameInAssets file name of the font from assets
       */
        public static void overrideFont(Context context, string defaultFontNameToOverride, string customFontFileNameInAssets)
        {
            try
            {
                var typeFace = Class.FromType(typeof(Typeface));
                var customfont = Typeface.CreateFromAsset(context.Assets, customFontFileNameInAssets);
                var font = typeFace.GetDeclaredField(defaultFontNameToOverride);
                font.Accessible = true;
                font.Set(null, customfont);
            }
            catch (System.Exception e)
            {
                var error = e.Message;
            }
        }
    }
}