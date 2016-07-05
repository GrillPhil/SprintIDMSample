using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using GalaSoft.MvvmLight.Views;

namespace Sprint.SESAT.IDMSample.Client.Droid.View.Activity
{
    [Activity(Icon = "@drawable/icon",
        Theme = "@style/SprintTheme.SplashScreen",
        ScreenOrientation = ScreenOrientation.Portrait,
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreen : ActivityBase
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var startupWork = new Task(() => {
                Task.Delay(1500);
            });

            startupWork.ContinueWith(t => {
                StartActivity(typeof(MainActivity));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}