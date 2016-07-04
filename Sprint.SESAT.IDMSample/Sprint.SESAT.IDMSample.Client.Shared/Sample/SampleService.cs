using Newtonsoft.Json;
using Sprint.SESAT.IDMSample.Client.Shared.AzureAD;
using Sprint.SESAT.IDMSample.Client.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.Sample
{
    public class SampleService : HttpServiceBase, ISampleService
    {
        private readonly string _baseUrl;

        public SampleService(ILoginService loginService, string baseUrl) : base(loginService)
        {
            _baseUrl = baseUrl;
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
    }
}
