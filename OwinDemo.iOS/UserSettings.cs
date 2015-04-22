using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Newtonsoft.Json;
using OwinDemo.Business.Domain;
using OwinDemo.Business.Models;
using ServiceLibrary;
using UIKit;

namespace OwinDemo.iOS
{
    public static class UserSettings
    {
        public async static void RefreshAuthenticationToken(ServiceWrapper serviceWrapper)
        {            
            var storedTokenData = NSUserDefaults.StandardUserDefaults.StringForKey("authenticationToken");

            if (storedTokenData != null)
            {
                var authenticationToken = new AuthenticationToken(storedTokenData);

                if (!authenticationToken.IsStillValid(DateTime.Now))
                {
                    TokenModel tokenModel = await serviceWrapper.GetAuthorizationTokenData();
                    NSUserDefaults.StandardUserDefaults.SetString(JsonConvert.SerializeObject(tokenModel), "authenticationToken");
                }    
            }
            else
            {
                TokenModel tokenModel = await serviceWrapper.GetAuthorizationTokenData();
                NSUserDefaults.StandardUserDefaults.SetString(JsonConvert.SerializeObject(tokenModel), "authenticationToken");
            }
            
        }

        public static string GetAuthenticationToken()
        {
            var storedTokenData = NSUserDefaults.StandardUserDefaults.StringForKey("authenticationToken");
            var authenticationToken = new AuthenticationToken(storedTokenData);

            return authenticationToken.access_token;
        }
    }
}