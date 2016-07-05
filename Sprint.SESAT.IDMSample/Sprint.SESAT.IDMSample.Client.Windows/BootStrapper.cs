using GalaSoft.MvvmLight.Ioc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Practices.ServiceLocation;
using Sprint.SESAT.IDMSample.Client.Shared;
using Sprint.SESAT.IDMSample.Client.Shared.AzureAD;
using Sprint.SESAT.IDMSample.Client.Shared.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Windows
{
    public class BootStrapper
    {
        public BootStrapper()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ILoginService>(LoginServiceFactory);
            SimpleIoc.Default.Register<ISampleService>(SampleServiceFactory);

            SimpleIoc.Default.Register<SampleViewModel>();
        }

        private ILoginService LoginServiceFactory()
        {
            return new LoginService(ConfigConstants.Resource,
                                    ConfigConstants.ClientId,
                                    ConfigConstants.Authority,
                                    ConfigConstants.RedirectUri,
                                    new PlatformParameters(PromptBehavior.Auto, false));
        }

        private ISampleService SampleServiceFactory()
        {
            return new SampleService(SimpleIoc.Default.GetInstance<ILoginService>(),
                                     ConfigConstants.BaseUrl);
        }

        public SampleViewModel SampleViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<SampleViewModel>();
            }
        }
    }
}
