using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.Sample
{
    public interface ISampleService
    {
        Task<IEnumerable<string>> GetAsync();
        Task<bool> LogoutAsync();
    }
}
