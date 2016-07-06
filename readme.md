#Azure Configuration
##Azure Test Subscription
- Free 30 day trial, started 05.07.2016
- 170 € credit

##Microsoft Account
Key|Value
---|---
Username|sprint.sesat.idmsample@outlook.com

##Resource Group
Key|Value
---|---
Name|Sprint.SESAT.IDMSample
Subscription|Visual Studio Ultimate bei MSDN (bauknecht@medialesson.de)

##Azure Web App with Sample Api
Key|Value
---|---
Endpoint|https://sprintsesatidmsample.azurewebsites.net
App Service Plan|SprintSESATIDMSample (Basic: 1 small, West Europe)

##Azure Active Directory
Key|Value
---|---
Name|Sprint.SESAT.IDMSample
Domain|SprintIDMSample.onmicrosoft.com

###Sample User
Key|Value
---|---
Name|John Doe
Username|johndoe@SprintIDMSample.onmicrosoft.com

###Azure AD Applications
####WebApi
Key|Value
---|---
Name|Sprint.SESAT.IDMSample.ADApp.Webapi
Type|Web Application
Sign-on Url|http://localhost:55555
App Id Uri|http://SprintIDMSample.onmicrosoft.com/Sprint.SESAT.IDMSample.ADApp.Webapi

####Native App
Key|Value
---|---
Name|Sprint.SESAT.IDMSample.ADApp.NativeApp
Type|Native Client Application
Redirect Uri|http://Sprint.SESAT.IDMSample.ADApp.NativeApp

##Azure Web App with Sample Api
Key|Value
---|---
Endpoint|https://sprintsample.azurewebsites.net
App Service Plan|SprintSESATIDMSample (Basic: 1 small)

##Using scopes to control client access
Scopes can be used to control how clients may interact with the resource (API). Each scope defines
a particular action, eg.:
- Read a user's calendar
- Send mail on behalf of user
- ...

When authenticating against the API, a set of scopes (defined in a comma-separated list) can be passed
in the request. The end-user will be asked to grant the application access to the data needed for the 
requested scopes. The access token returned to the client then is valid for performing the requested actions.

Scopes are defined in the application manifest's "oauth2Permissions" array. The following example shows a definition
for a scope to get full access to a user's ToDo list.

```json
"oauth2Permissions": [
{
    "adminConsentDescription": "Allow the application full access to the Todo List service on behalf of the signed-in   user",
    "adminConsentDisplayName": "Have full access to the Todo List service",
    "id": "b69ee3c9-c40d-4f2a-ac80-961cd1534e40",
    "isEnabled": true,
    "type": "User",
    "userConsentDescription": "Allow the application full access to the todo service on your behalf",
    "userConsentDisplayName": "Have full access to the todo service",
    "value": "user_impersonation"
    }
]
```
The client can then use the scope's key value "user_impersonation" to request access.

## Roles based access control (RBAC)
Within the application, access to certain functionality is restricted to subsets of users. For instance, not every user has the ability to create a support request on a Sprint project.
This kind of authorization is implemented using role based access control (RBAC). When using RBAC, an administrator grants permissions to roles, not to individual users or groups. 
The administrator can then assign roles to different users and groups to control who has access to what content and functionality.

Just as scopes, roles can be defined in the application manifest file in the management portal. The following shows how to define the "Admin" role for an application.

```json
"appRoles": [
    {
      "allowedMemberTypes": [
        "User"
      ],
      "description": "Admins can manage roles and perform all task actions.",
      "displayName": "Admin",
      "id": "81e10148-16a8-432a-b86d-ef620c3e48ef",
      "isEnabled": true,
      "origin": "Application",
      "value": "Admin"
    }
  ]
  ```

### Backend Configuration
When writing API endpoints, use the authorize tag to restrict the API to spcific roles. Here's an example of a GET API endpoint that restricts
access to Admins, Sprint Partners and Insurances. We can then proceed and perform different actions based on the user's actual role:
```c#
[HttpGet]
[Authorize(Roles = "Admin, SprintPartner, Insurance")]
public object GetObject()
{
    if (User.IsInRole("Admin"))
    {
        // Do admin action here...
    }
    else if (User.IsInRole("SprintPartner"))
    {
        // Do sprint partner action here...
    }
    ...
}
```

To retrieve a user's roles, use
```c# 
ClaimsIdentity claimsId = ClaimsPrincipal.Current.Identity as ClaimsIdentity;
var appRoles = new List<String>();
foreach (Claim claim in ClaimsPrincipal.Current.FindAll(claimsId.RoleClaimType))
    appRoles.Add(claim.Value);
```


#Notes
- Using ModernHttpClient to properly handle https requests for iOS and Android.

#Resources
- http://bitoftech.net/2014/09/12/secure-asp-net-web-api-2-azure-active-directory-owin-middleware-adal/
- https://github.com/Azure-Samples/active-directory-dotnet-native-multitarget
- http://stackoverflow.com/questions/32172898/azure-active-directory-logout-with-adal-library
