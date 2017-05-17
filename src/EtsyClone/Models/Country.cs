using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EtsyClone.Models
{
    public class Country
    {
        public int country_id { get; set; }
        public string name { get; set; }

        public static List<Country> GetCountries()
        {
            var client = new RestClient("https://openapi.etsy.com/v2/");
            var request = new RestRequest("countries?api_key=" + EnvironmentVariables.EtsyKey, Method.GET);
            //request.AddHeader("User-Agent", "alexandraholcombe");
            //request.AddHeader("Accept", "application/json");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var countryList = JsonConvert.DeserializeObject<List<Country>>(jsonResponse.ToString());
            return countryList;
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
