using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint.SESAT.IDMSample.Client.Shared
{
    public static class ConfigConstants
    {
        public static string BaseUrl = "https://sprintsample.azurewebsites.net/api/";
        public static string Resource = "http://SprintSample.onmicrosoft.com/Sprint.SESAT.IDMSample.ADApp.Webapi";
        public static string ClientId = "cbe60fcb-5c37-4884-8658-5e8905efdfc8";
        public static string Authority = "https://login.windows.net/SprintSample.onmicrosoft.com";
        public static Uri RedirectUri = new Uri("http://Sprint.SESAT.IDMSample.ADApp.NativeApp");
    }
}
