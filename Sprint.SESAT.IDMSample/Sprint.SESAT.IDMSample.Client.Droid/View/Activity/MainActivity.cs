using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Sprint.SESAT.IDMSample.Client.Droid.Utils;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;

namespace Sprint.SESAT.IDMSample.Client.Droid.View.Activity
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Android.App.Activity
    {
        private ListView _lstView;
        private SampleViewModel _viewModel;
        private Button _button;
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
            _button = FindViewById<Button>(Resource.Id.MyButton);
            _lstView = FindViewById<ListView>(Resource.Id.sampleListView);

            var bootStrapper = new BootStrapper(this);
            _viewModel = SimpleIoc.Default.GetInstance<SampleViewModel>();
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;

            _button.Click += delegate 
            {
                if (_viewModel.IsLoggedIn)
                {
                    _viewModel.LogoutCommand.Execute(null);
                }
                else
                {
                    _viewModel.LoadDataCommand.Execute(null);
                }
            };

            _viewModel.LoadDataCommand.Execute(null);
        }

        protected override void OnDestroy()
        {
            _viewModel.PropertyChanged -= _viewModel_PropertyChanged;
            base.OnDestroy();
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(_viewModel.IsLoggedIn)))
            {
                _button.Text = _viewModel.IsLoggedIn ? "Logout" : "Load Data";
            }
            else if (e.PropertyName.Equals(nameof(_viewModel.SampleList)))
            {
                _lstView.Adapter = new SampleAdapter(_viewModel.SampleList, this);
            }
        }
    }
}

