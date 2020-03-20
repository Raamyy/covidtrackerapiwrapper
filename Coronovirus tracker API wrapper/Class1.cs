﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CoronavirusApiWrapper
{
    public class CoronvirusData
    {
        //Initiates client
        public static IRestClient client = new RestClient("https://coronavirus-tracker-api.herokuapp.com/");

        //Sends a GET request to the API
        public static IRestRequest  request = new RestRequest("v2/latest", Method.GET);

        //Fetches the response from the API
        public IRestResponse response = client.Execute(request);

        public string LatestConfirmed()
        {
            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);
 
            //Stores the 'latest' node in the result variable
            var LatestData = output["latest"];

            //The 'confirmed' sub node of the 'latest' node  is fetched and converted into a string
            var LatestConfirmedData = LatestData["confirmed"].ToString();
            return LatestConfirmedData;
        }

        public string LatestRecovered()
        {
            //Deserializes the reponse
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the result variable
            var LatestData = output["latest"];

            //The 'recovered' sub node of the 'latest' node  is fetched and converted into a string
            var LatestRecoveredData = LatestData["recovered"].ToString();
            return LatestRecoveredData;
        }

        public string LatestDeaths()
        {
            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the result variable
            var LatestData = output["latest"];

            //The 'death' sub node of the 'latest' node  is fetched and converted into a string
            var LatestDeathsData = LatestData["deaths"].ToString();
            return LatestDeathsData;
        }
    }
}