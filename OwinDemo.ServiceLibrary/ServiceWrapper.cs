using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OwinDemo.Business.Models;

namespace ServiceLibrary
{
    public class ServiceWrapper : IServiceWrapper
    {
        public async Task<TokenModel> GetAuthorizationTokenData()
        {
            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password")
                });


                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YmM4NTJmZGIzMTFkNGFkYjlkMjJkZmE4MjI2YjM5MWE6TXpBMU1ESTRNVGhsWmpVeE5EVm1OVGd6TkRNMllXSTRNelE0TnpnM05qZz0=");
                var postResponse = await client.PostAsync("http://authz.azurewebsites.net/oauth2/token", formContent);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(response);
            }
        }

        public async Task<bool> ValidateUser(UserLoginModel loginModel, string authenticationToken)
        {
            if (!loginModel.IsValid())
            {
                return false;
            }

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", loginModel.Username),
                    new KeyValuePair<string, string>("Password", loginModel.Password)
                });

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + authenticationToken);
                var postResponse = await client.PostAsync("http://resz.azurewebsites.net/User/ValidateUser", formContent);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return response.Equals("true");
            }
        }

        public async Task<string> RegisterUser(UserLoginModel loginModel, string authenticationToken)
        {
            if (!loginModel.IsValid())
            {
                return "invalid_model";
            }

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", loginModel.Username),
                    new KeyValuePair<string, string>("Password", loginModel.Password)
                });

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + authenticationToken);
                var postResponse = await client.PostAsync("http://resz.azurewebsites.net/User/createUser", formContent);
                postResponse.EnsureSuccessStatusCode();

                return await postResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
