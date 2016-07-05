using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Microsoft.Practices.ServiceLocation;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;
using UIKit;

namespace Sprint.SESAT.IDMSample.Client.iOS
{
    class MainViewController : UIViewController
    {
        private SampleViewModel _sampleViewModel;

        private UITableView _sampleDataTableView;
        private UIActivityIndicatorView _loadingIndicator;
        private UIBarButtonItem _logoutButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _sampleViewModel = ServiceLocator.Current.GetInstance<SampleViewModel>();
            _sampleViewModel.PropertyChanged += _sampleViewModel_PropertyChanged;

            setupNavigationBar();
            setupToolBar();
            setupViewElements();

            _sampleViewModel.LoadDataCommand.Execute(null);
        }

        private void setupViewElements()
        {
            View.BackgroundColor = UIColor.White;

            _loadingIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray)
            {
                HidesWhenStopped = true,
                Center = View.Center
            };

            _sampleDataTableView = new UITableView()
            {
                TableFooterView = new UIView(CGRect.Empty),
                TranslatesAutoresizingMaskIntoConstraints = false,
                Hidden = true
            };

            View.AddSubviews(_sampleDataTableView, _loadingIndicator);

            NSLayoutConstraint.Create(_sampleDataTableView, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, View,
                NSLayoutAttribute.Top, 1, 8).Active = true;
            NSLayoutConstraint.Create(_sampleDataTableView, NSLayoutAttribute.BottomMargin, NSLayoutRelation.Equal, View,
                NSLayoutAttribute.Bottom, 1, -8).Active = true;
            NSLayoutConstraint.Create(_sampleDataTableView, NSLayoutAttribute.LeftMargin, NSLayoutRelation.Equal, View,
                NSLayoutAttribute.Left, 1, 8).Active = true;
            NSLayoutConstraint.Create(_sampleDataTableView, NSLayoutAttribute.RightMargin, NSLayoutRelation.Equal, View,
                NSLayoutAttribute.Right, 1, -8).Active = true;
        }   

        private void setupToolBar()
        {
            NavigationController.ToolbarHidden = false;
            var loadDataButton = new UIBarButtonItem("Load Data", UIBarButtonItemStyle.Plain, (s, e) => { _sampleViewModel.LoadDataCommand.Execute(null); });
            ToolbarItems = new[] { new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace), loadDataButton, new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) };
        }

        private void setupNavigationBar()
        {
            Title = "Sprint.SESAT.IDMSample";
            NavigationController.NavigationBar.Translucent = false;
            _logoutButton = new UIBarButtonItem("Logout", UIBarButtonItemStyle.Plain, (s, e) => {_sampleViewModel.LogoutCommand.Execute(null); });
        }

        private void _sampleViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(_sampleViewModel.IsLoading)))
            {
                if (_sampleViewModel.IsLoading)
                    _loadingIndicator.StartAnimating();
                else
                    _loadingIndicator.StopAnimating();
            }
            else if (e.PropertyName.Equals(nameof(_sampleViewModel.SampleList)))
            {
                _sampleDataTableView.Source = new SampleDataTableViewSource(_sampleViewModel.SampleList);
                _sampleDataTableView.ReloadData();
                _sampleDataTableView.Hidden = false;
            }
            else if (e.PropertyName.Equals(nameof(_sampleViewModel.IsLoggedIn)))
            {
                NavigationItem.RightBarButtonItem = _sampleViewModel.IsLoggedIn ? _logoutButton : null;
            }
        }
    }
}
