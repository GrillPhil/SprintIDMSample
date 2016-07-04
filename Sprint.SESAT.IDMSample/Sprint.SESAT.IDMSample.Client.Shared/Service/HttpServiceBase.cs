using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ModernHttpClient;
using Sprint.SESAT.IDMSample.Client.Shared.AzureAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.Service
{
    public abstract class HttpServiceBase
    {
        private readonly ILoginService _loginService;

        public HttpServiceBase(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Factory for HttpClient, respects Authorization attribute
        /// </summary>
        /// <param name="methodName">Default to CallerMemberName. Needed for reflection to detect Authorization attribute</param>
        /// <returns></returns>
        internal async Task<HttpClient> CreateHttpClient([CallerMemberName]string methodName = null)
        {
            // Uses ModernHttpClient to enable better performance and correct handling of HTTPS under Android and iOS
            var httpClient = new HttpClient(new NativeMessageHandler());

            // Scan for Authorization attribute
            var typeInfo = this.GetType().GetTypeInfo();
            var methodInfo = typeInfo.GetDeclaredMethod(methodName);
            var attribute = methodInfo.GetCustomAttribute<Authorize>();

            if (attribute != null)
            {
                try
                {
                    // Login and set authorization header if required.
                    var authResult = await _loginService.LoginAsync();
                    if (authResult != null &&
                        !string.IsNullOrEmpty(authResult.AccessToken) &&
                        !string.IsNullOrEmpty(authResult.AccessTokenType))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authResult.AccessTokenType, authResult.AccessToken);
                    }
                }
                catch (AdalServiceException ex) when (ex.ErrorCode == "authentication_canceled")
                {
                    // todo: user has canceled login
                }
                // todo: error handling
            }

            return httpClient;
        }

        public async void LogoutAsync()
        {
            var requestUrl = ConfigConstants.LogoutUrl;
            using (var httpClient = await CreateHttpClient())
            {
                try
                {
                    var jsonString = await httpClient.GetStringAsync(requestUrl);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
