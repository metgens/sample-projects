using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Sample.AdMob;

namespace Xamarin.Sample.Droid
{
    [Activity(Label = "Xamarin.Sample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Forms.DependencyService.Register<AdmobService>();

            LoadApplication(new App());
        }
    }
}

