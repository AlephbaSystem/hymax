using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Webkit;
using Android.Widget;
using Java.IO;
using Java.Lang;
using Java.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hymax.Droid
{
    [Activity(Label = "AlertActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class AlertActivity : Activity
    {
        private static string TAG = "AlertActivity";
        ImageView car;
        int howMuch = 0;
        ImageButton icon;
        private int image;
        TextView income;
        bool keepGoing = true;

        /* renamed from: mp */
        MediaPlayer f95mp = new MediaPlayer();
        private string msg;
        bool playSound = false;
        string state = "";
        //Techniques teq = Techniques.Shake;

        /* renamed from: v */
        Vibrator f96v;
        public override void OnAttachedToWindow()
        {
            Window.AddFlags(WindowManagerFlags.ShowWhenLocked |
                            WindowManagerFlags.KeepScreenOn |
                            WindowManagerFlags.DismissKeyguard |
                            WindowManagerFlags.TurnScreenOn);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_alert);

            income = FindViewById<TextView>(Resource.Id.alert_text);
            icon = FindViewById<ImageButton>(Resource.Id.alert_icon);
            car = FindViewById<ImageView>(Resource.Id.alert_car);

            //ButterKnife.bind((Activity)this);
            this.f96v = (Vibrator)GetSystemService("vibrator");
            //SetAudio();
            this.msg = "";
            //if (this.state.contains("ضربه"))
            //{
            //    this.msg = "به خودرو ضربه وارد شده است!";
            //    //this.teq = Techniques.Shake;
            //    this.image = Resource.Drawable.icon_alert_warning_zarbe;
            //}
            //else if (this.state.contains("سرقت"))
            //{
            this.msg = "خطر سرقت خودرو";
            //this.teq = Techniques.Shake;
            this.image = Resource.Drawable.icon_alert_warning_serqat;
            //}
            //else
            //{
            //    Finish();
            //}
            updateDisplay();

            icon.Click += delegate
            {
                this.keepGoing = false;
                this.f96v.Cancel();
                this.f95mp.Stop();
                this.Finish();
            };

            var metrics = new DisplayMetrics();
            var windowManager = this.GetSystemService(Context.WindowService) as IWindowManager;
            windowManager?.DefaultDisplay.GetMetrics(metrics);


            car.Animate().TranslationY((float)metrics.HeightPixels).SetDuration(1000).SetInterpolator(new DecelerateInterpolator()).SetStartDelay(2).Start();
            icon.Animate().SetInterpolator(new DecelerateInterpolator()).ScaleX(0.0f).ScaleY(0.0f).SetDuration(550).SetStartDelay(2).Start();
            onPrepared();
            //PropertyAction carAction = PropertyAction.newPropertyAction(this.car).translationY((float)metrics.HeightPixels).duration(1000).interpolator(new DecelerateInterpolator()).build();
            //PropertyAction headerAction = PropertyAction.newPropertyAction(this.icon).interpolator(new DecelerateInterpolator()).scaleX(0.0f).scaleY(0.0f).duration(550).build();
            //Player.init().animate(carAction).then().animate(headerAction).then().animate(PropertyAction.newPropertyAction(this.income).interpolator(new DecelerateInterpolator()).scaleX(0.0f).scaleY(0.0f).duration(550).build()).play();
        }

        private void setAudio()
        {
            try
            {
                this.f95mp.Stop();
                this.f95mp.Release();
            }
            catch
            {
            }
            this.f95mp = new MediaPlayer();
            //this.f95mp.SetAudioStreamType(Stream.Music);

            this.f95mp = MediaPlayer.Create(this, Resource.Raw.car_alarm);

            this.playSound = true;
            this.f95mp.Looping = true;
        }

        private void updateDisplay()
        {
            this.income.Text = this.msg;
            this.icon.SetImageDrawable(GetDrawable(Resource.Drawable.icon_alert_warning));
            showAnimationCar();
            showAnimationButton();
        }

        /* access modifiers changed from: private */
        public void showAnimationButton()
        {
            if (this.keepGoing)
            {
                if (this.howMuch == 9)
                {
                    this.keepGoing = false;
                    if (this.playSound)
                    {
                        setAudio();
                    }
                    this.f95mp.Start();
                    return;
                }
                this.howMuch++;
                this.f96v.Vibrate(500);
            }
        }

        /* access modifiers changed from: private */
        public void showAnimationCar()
        {
            if (this.keepGoing)
            {

            }
        }

        /* access modifiers changed from: protected */
        protected override void OnStop()
        {
            base.OnStop();
            this.f96v.Cancel();
            this.f95mp.Stop();
        }

        protected override void OnDestroy()
        {
            this.f96v.Cancel();
            this.f95mp.Stop();
            this.f95mp.Release();
            base.OnDestroy();
        }

        /* access modifiers changed from: protected */
        protected override void OnPause()
        {
            this.f96v.Cancel();
            this.f95mp.Stop();
            base.OnPause();
        }

        public void onPrepared()
        {
            this.playSound = true;
            this.f95mp.Start();
        }
    }

}