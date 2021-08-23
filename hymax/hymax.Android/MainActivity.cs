
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.Permissions;
using Android;
using Plugin.Fingerprint;
using Android.Content;
using Acr.UserDialogs;

namespace hymax.Droid
{
    [Activity(Label = "hymax", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    { 
        //GlobalServices iGlobalServices;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //TypefaceUtil.overrideFont(base.ApplicationContext, "Dirooz", "Dirooz.ttf");

            global::Xamarin.Forms.Forms.SetFlags(new string[] { "IndicatorView_Experimental", "CollectionView_Experimental" });

            //iGlobalServices = new GlobalServices();
            //var intentFilter = new IntentFilter("android.provider.Telephony.SMS_RECEIVED");
            //intentFilter.Priority = 999;
            //RegisterReceiver(iGlobalServices.mReceiver, intentFilter);

            CrossFingerprint.SetCurrentActivityResolver(() => this);
            UserDialogs.Init(this);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            LoadApplication(new App());

            var serviceToStart = new Intent(this, typeof(GlobalServices));
            StartService(serviceToStart);
        }
        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }

        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            //UnregisterReceiver(sMSReceiver);
        }

    }
}