﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.Sample
{
    public class SampleViewModel : ViewModelBase
    {
        private readonly ISampleService _sampleService;

        private bool _isLoading = false;
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
            SampleList = await _sampleService.GetAsync();
            IsLoading = false;
        }

        private async void logout()
        {
            IsLoading = true;
            await _sampleService.LogoutAsync();
            IsLoading = false;
        }
    }
}
