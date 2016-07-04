using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.AzureAD
{
    public class LoginService : ILoginService
    {
        private readonly string _resource;
        private readonly string _clientId; 
        private readonly string _authority;
        private readonly Uri _redirectUri;
        private readonly IPlatformParameters _platformParameters;

        public LoginService(string resource,
                            string clientId,
                            string authority,
                            Uri redirectUri,
                            IPlatformParameters platformParameters)
        {
            _resource = resource;
            _clientId = clientId;
            _authority = authority;
            _redirectUri = redirectUri;
            _platformParameters = platformParameters;
        }

        public async Task<AuthenticationResult> LoginAsync()
        {
            var authContext = new AuthenticationContext(_authority);
            var authResult = await authContext.AcquireTokenAsync(_resource, _clientId, _redirectUri, _platformParameters);
            return authResult;
        }
    }
}
