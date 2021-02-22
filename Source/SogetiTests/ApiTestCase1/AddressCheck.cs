using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RestSharp;

namespace SogetiTests.ApiTestCase1
{

    /// <summary>
    /// API Test to verify information about stuttgart.
    /// </summary>
    [TestClass]
    public class AddressCheck
    {

        #region Test methods

        /// <summary>
        ///  API Test to verify information about stuttgart.
        /// </summary>
        [TestMethod]
        public void AddressApiTest()
        {
            // API Url
            string url = "http://api.zippopotam.us/de/bw/stuttgart";

            // Stopwatch for computing the time elapsed.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; Uncomment only if needed.

            // Use RestClient for invoking API
            var client = new RestClient(url);
            var response = client.Execute(new RestRequest());

            // Comput the time consumed for performing the API fetch.
            long timeTakenInMilliseconds = stopwatch.ElapsedMilliseconds;

            // Ensure the return code is 200 (HttpStatusCode.OK).
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Error fetching API :" + url);

            // Ensure the return content type is JSON
            Assert.AreEqual(response.ContentType, "application/json", "Expected context type is JSON");

            // Ensure the service invocation does not exceed 1 second.
            Assert.IsTrue(timeTakenInMilliseconds < 2000, "Time taken to fetch API data exceeds one second. Time taken in millisec : " + timeTakenInMilliseconds);

            // Deserialize the JOSN text to Country class.
            var country = JsonConvert.DeserializeObject<Country>(response.Content);

            // Verify that Stuttgart belongs to the country Germany and to the state Baden-Württemberg.
            Assert.AreEqual("Germany", country.CountryName, "Country name mismatch");
            Assert.AreEqual("Baden-Württemberg", country.State, "State name mismatch");

            // Postal code to search
            string postCodeToSearch = "70597";

            // Find a place for the postal code 
            Place place = country.Places.FirstOrDefault(p => p.PostCode == postCodeToSearch);
            Assert.IsNotNull(place, "Could not find place for " + postCodeToSearch);

            // Ensure the name of the place is 'Stuttgart Degerloch'
            string expectedPlaceName = "Stuttgart Degerloch";
            Assert.AreEqual(expectedPlaceName, place.PlaceName, "Could not find the place name :" + expectedPlaceName);
        }

        #endregion
    }

    /// <summary>
    /// A class to represent Country
    /// </summary>
    public class Country
    {
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }

        [JsonProperty("places")]
        public List<Place> Places { get; set; }

        [JsonProperty("country")]
        public string CountryName { get; set; }

        [JsonProperty("place name")]
        public string PlaceName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; }
    }


    /// <summary>
    /// Class to represent a Place
    /// </summary>
    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName {get;set;}

        [JsonProperty("longitude")]
        public  float Longitude { get; set; }

        [JsonProperty("post code")]
        public string PostCode { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }
    }

}
