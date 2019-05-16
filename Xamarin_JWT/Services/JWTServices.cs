using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin_JWT.Helper;
using Xamarin_JWT.Models;

namespace Xamarin_JWT.Services
{
    public class JWTServices
    {

        private static string BASE_URL = "http://jwtoauth.azurewebsites.net/api/";

        public JWTServices()
        {
        }


        public async Task<string> LoginAsync(string userName, string password)
        {

            var loginModel = new LoginModel(userName, password);
            var json = JsonConvert.SerializeObject(loginModel);

            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "token");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            JObject jObject = JsonConvert.DeserializeObject<dynamic>(content);
            var accessToken = jObject.Value<string>("token");

            UserSettings.ACCESS_TOKEN = accessToken;
            //System.Diagnostics.Debug.Write(accessToken);
            return accessToken; 

        }


        public async Task<List<CricketerModel>> GetCricketers()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserSettings.ACCESS_TOKEN);

            var json = await client.GetStringAsync(BASE_URL + "cricketers");
            System.Diagnostics.Debug.Write(json);

            var cricketers = JsonConvert.DeserializeObject<List<CricketerModel>>(json);
            return cricketers;
        }

    }
}
