using Xamarin.Sample.Common;
using Android.App;
using Android.Gms.Ads;
using Xamarin.Sample.AdMob;

[assembly: Xamarin.Forms.Dependency(typeof(AdmobService))]
namespace Xamarin.Sample.AdMob
{
    public class AdmobService : IAdService
    {
        private static string _adUnit = "ca-app-pub-3940256099942544/1033173712";


        public void ShowInterstital()
        {

            var context = Application.Context;
            var ad = new InterstitialAd(context);
            ad.AdUnitId = _adUnit;

            var intlistener = new InterstitialAdListener(ad);

            ad.AdListener = intlistener;

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            ad.LoadAd(requestbuilder.Build());


        }
    }
}