using GalaSoft.MvvmLight.Ioc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Practices.ServiceLocation;
using Sprint.SESAT.IDMSample.Client.Shared;
using Sprint.SESAT.IDMSample.Client.Shared.AzureAD;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;
using UIKit;

namespace Sprint.SESAT.IDMSample.Client.iOS
{
    public class BootStrapper
    {
        public BootStrapper(UIViewController rootViewController)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<ILoginService>())
                SimpleIoc.Default.Register<ILoginService>(() => loginServiceFactory(rootViewController));
            if (!SimpleIoc.Default.IsRegistered<ISampleService>())
                SimpleIoc.Default.Register<ISampleService>(sampleServiceFactory);

            if (!SimpleIoc.Default.IsRegistered<SampleViewModel>())
                SimpleIoc.Default.Register<SampleViewModel>();
        }

        private ILoginService loginServiceFactory(UIViewController rootViewController)
        {
            return new LoginService(ConfigConstants.Resource,
                                    ConfigConstants.ClientId,
                                    ConfigConstants.Authority,
                                    ConfigConstants.RedirectUri, new PlatformParameters(rootViewController));
        }

        private ISampleService sampleServiceFactory()
        {
            return new SampleService(SimpleIoc.Default.GetInstance<ILoginService>(),
                                     ConfigConstants.BaseUrl);
        }
    }
}
