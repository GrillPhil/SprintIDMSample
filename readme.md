#Todos
- Error Handling
- Logout
- iOS Demo Client
- groups/scopes to hide/show features in client
- groups/scopes to respect in web api
- styling/customization of login experience

#Azure Configuration
##Resource Group
Key|Value
-|-
Name|Sprint.SESAT.IDMSample
Subscription|Visual Studio Ultimate bei MSDN (bauknecht@medialesson.de)

##Azure Active Directory
Key|Value
-|-
Name|Sprint.SESAT.IDMSample
Domain|SprintSample.onmicrosoft.com

###Sample User
Key|Value
-|-
Name|John Doe
Username|johndoe@sprintsample.onmicrosoft.com
Password|Sprint!2016

###Azure AD Applications
####WebApi
Key|Value
-|-
Name|Sprint.SESAT.IDMSample.ADApp.Webapi
Type|Web Application
Sign-on Url|http://localhost:55555
App Id Uri|http://SprintSample.onmicrosoft.com/Sprint.SESAT.IDMSample.ADApp.Webapi

#####manifest.json
```json
{
  "appId": "e6ce8ac7-d4ea-4742-b205-2520c5e7c792",
  "appRoles": [],
  "availableToOtherTenants": false,
  "displayName": "Sprint.SESAT.IDMSample.ADApp.Webapi",
  "errorUrl": null,
  "groupMembershipClaims": null,
  "homepage": "http://localhost:55555",
  "identifierUris": [
    "http://SprintSample.onmicrosoft.com/Sprint.SESAT.IDMSample.ADApp.Webapi"
  ],
  "keyCredentials": [],
  "knownClientApplications": [],
  "logoutUrl": null,
  "oauth2AllowImplicitFlow": false,
  "oauth2AllowUrlPathMatching": false,
  "oauth2Permissions": [
    {
      "adminConsentDescription": "Allow the application to access Sprint.SESAT.IDMSample.ADApp.Webapi on behalf of the signed-in user.",
      "adminConsentDisplayName": "Access Sprint.SESAT.IDMSample.ADApp.Webapi",
      "id": "7d5ca970-9cab-4a18-ad1f-4285611358b6",
      "isEnabled": true,
      "origin": "Application",
      "type": "User",
      "userConsentDescription": "Allow the application to access Sprint.SESAT.IDMSample.ADApp.Webapi on your behalf.",
      "userConsentDisplayName": "Access Sprint.SESAT.IDMSample.ADApp.Webapi",
      "value": "user_impersonation"
    }
  ],
  "oauth2RequirePostResponse": false,
  "passwordCredentials": [],
  "publicClient": null,
  "replyUrls": [
    "http://localhost:55555"
  ],
  "requiredResourceAccess": [
    {
      "resourceAppId": "00000002-0000-0000-c000-000000000000",
      "resourceAccess": [
        {
          "id": "311a71cc-e848-46a1-bdf8-97ff7156d8e6",
          "type": "Scope"
        }
      ]
    }
  ],
  "samlMetadataUrl": null,
  "extensionProperties": [],
  "objectType": "Application",
  "objectId": "f82ee68c-4115-420b-add8-331832dbd93f",
  "deletionTimestamp": null,
  "createdOnBehalfOf": null,
  "createdObjects": [],
  "manager": null,
  "directReports": [],
  "members": [],
  "memberOf": [],
  "owners": [],
  "ownedObjects": []
}
```

####Native App
Key|Value
-|-
Name|Sprint.SESAT.IDMSample.ADApp.NativeApp
Type|Native Client Application
Redirect Uri|http://Sprint.SESAT.IDMSample.ADApp.NativeApp

##Azure Web App with Sample Api
Key|Value
-|-
Endpoint|https://sprintsample.azurewebsites.net
App Service Plan|SprintSESATIDMSample (Basic: 1 small)

#Using scopes to control client access
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

#Notes
- Using ModernHttpClient to properly handle https requests for iOS and Android.

#Resources
- http://bitoftech.net/2014/09/12/secure-asp-net-web-api-2-azure-active-directory-owin-middleware-adal/
- https://github.com/Azure-Samples/active-directory-dotnet-native-multitarget
- http://stackoverflow.com/questions/32172898/azure-active-directory-logout-with-adal-library
