using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.Sample
{
    public class SampleViewModel : ViewModelBase
    {
        private readonly ISampleService _sampleService;

        private bool _isLoading = false;
        private bool _isLoggedIn;
        private IEnumerable<string> _sampleList;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                _isLoading = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }

            set
            {
                _isLoggedIn = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<string> SampleList
        {
            get
            {
                return _sampleList;
            }

            set
            {
                _sampleList = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand LoadDataCommand { get; private set; }

        public RelayCommand LogoutCommand { get; set; }

        public SampleViewModel(ISampleService sampleService)
        {
            _sampleService = sampleService;
            LoadDataCommand = new RelayCommand(loadData);
            LogoutCommand = new RelayCommand(logout);
        }

        private async void loadData()
        {
            IsLoading = true;
            try
            {
                SampleList = await _sampleService.GetAsync();
                IsLoggedIn = true;
            }
            catch (HttpRequestException ex)
            {
                // do nothing
            }
            
            IsLoading = false;
        }

        private async void logout()
        {
            IsLoading = true;
            var success = await _sampleService.LogoutAsync();
            if (success)
            {
                IsLoggedIn = false;
                SampleList = new List<string>();
                loadData();
            }
            IsLoading = false;
        }
    }
}
