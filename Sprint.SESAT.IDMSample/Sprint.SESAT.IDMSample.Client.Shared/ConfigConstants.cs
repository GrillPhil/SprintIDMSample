using System;

namespace Sprint.SESAT.IDMSample.Client.Shared
{
    public static class ConfigConstants
    {
        // Azure Test Endpoint
        public static string BaseUrl = "https://sprintsesatidmsample.azurewebsites.net/api/";

        // Azure AD Configuration
        public static string Resource = "http://SprintIDMSample.onmicrosoft.com/Sprint.SESAT.IDMSample.ADApp.Webapi";
        public static string ClientId = "7e9718b3-0ccb-4ebe-8508-160000216916";
        public static string Authority = "https://login.windows.net/SprintIDMSample.onmicrosoft.com";
        public static Uri RedirectUri = new Uri("http://Sprint.SESAT.IDMSample.ADApp.NativeApp");
        public static string LogoutUrl = "https://login.windows.net/SprintIDMPSample.onmicrosoft.com/oauth2/logout?post_logout_redirect_uri=https://SprintIDMSample.azurewebsites.net/Logout";
    }
}
