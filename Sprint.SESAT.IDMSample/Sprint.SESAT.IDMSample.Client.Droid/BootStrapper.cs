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
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Sprint.SESAT.IDMSample.Client.Shared.AzureAD;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;
using Sprint.SESAT.IDMSample.Client.Shared;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Sprint.SESAT.IDMSample.Client.Droid
{
    public class BootStrapper
    {
        public BootStrapper(Activity callerActivity)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<ILoginService>())
                SimpleIoc.Default.Register<ILoginService>(()=> LoginServiceFactory(callerActivity));
            if (!SimpleIoc.Default.IsRegistered<ISampleService>())
                SimpleIoc.Default.Register<ISampleService>(SampleServiceFactory);

            if (!SimpleIoc.Default.IsRegistered<SampleViewModel>())
                SimpleIoc.Default.Register<SampleViewModel>();
        }

        private ILoginService LoginServiceFactory(Activity callerActivity)
        {
            return new LoginService(ConfigConstants.Resource,
                                    ConfigConstants.ClientId,
                                    ConfigConstants.Authority,
                                    ConfigConstants.RedirectUri,
                                    new PlatformParameters(callerActivity));
        }

        private ISampleService SampleServiceFactory()
        {
            return new SampleService(SimpleIoc.Default.GetInstance<ILoginService>(),
                                     ConfigConstants.BaseUrl);
        }
    }
}