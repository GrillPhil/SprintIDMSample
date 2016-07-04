using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Sprint.SESAT.IDMSample.Client.Droid
{
    [Activity()]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            var bootStrapper = new BootStrapper(this);
            var vm = SimpleIoc.Default.GetInstance<SampleViewModel>();

            button.Click += delegate 
            {
                button.Text = string.Format("{0} clicks!", count++);
                vm.LoadDataCommand.Execute(null);
            };
        }
    }
}

