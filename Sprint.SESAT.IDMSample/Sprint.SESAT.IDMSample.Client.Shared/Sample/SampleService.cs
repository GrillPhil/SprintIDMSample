using Newtonsoft.Json;
using Sprint.SESAT.IDMSample.Client.Shared.AzureAD;
using Sprint.SESAT.IDMSample.Client.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.Sample
{
    public class SampleService : HttpServiceBase, ISampleService
    {
        private readonly string _baseUrl;
        private readonly ILoginService _loginService;
        
        public SampleService(ILoginService loginService, string baseUrl) : base(loginService)
        {
            _baseUrl = baseUrl;
            _loginService = loginService;
        }

        [Authorize()]
        public async Task<IEnumerable<string>> GetAsync()
        {
            var requestUrl = $"{_baseUrl}Sample";
            using (var httpClient = await CreateHttpClient())
            {
                try
                {
                    var jsonString = await httpClient.GetStringAsync(requestUrl);
                    var result = JsonConvert.DeserializeObject<IEnumerable<string>>(jsonString);
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [Authorize()]
        public async Task<bool> LogoutAsync()
        {
            _loginService.Logout();

            string requestUrl = ConfigConstants.LogoutUrl;

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode) return true;
            }
            catch (Exception ex)
            {
                // todo: catch exception and handle error
            }
            return false;
        }
    }
}
