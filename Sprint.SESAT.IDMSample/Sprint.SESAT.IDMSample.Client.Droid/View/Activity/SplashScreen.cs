using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace Sprint.SESAT.IDMSample.Client.Droid.View.Activity
{
    [Activity(Icon = "@drawable/icon", 
              Theme = "@style/SprintTheme.SplashScreen", 
              MainLauncher = true, 
              NoHistory = true)]
    public class SplashScreen : ActivityBase
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}