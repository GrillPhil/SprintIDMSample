using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared.AzureAD
{
    public interface ILoginService
    {
        Task<AuthenticationResult> LoginAsync();
    }
}
