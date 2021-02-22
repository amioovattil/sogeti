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
using SogetiTests.ApiTestCase1;

namespace SogetiTests.ApiTestCase2
{

    /// <summary>
    /// A data driven API test using a CSV file as input.
    /// </summary>
    [TestClass]
    public class PlaceCheck
    {

        #region Properties

        /// <summary>
        /// Context through which MSTest supplies one line of data from CSV file.
        /// </summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Test method

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"..\..\ApiTestCase2\data.csv", "Data#csv",DataAccessMethod.Sequential)]
        public void PlaceCheckApiTest()
        {
            // Fetch column values from single row in CSV file
            string countryCode = TestContext.DataRow.ItemArray[0].ToString();
            string postalCode = TestContext.DataRow.ItemArray[1].ToString();
            string placeName = TestContext.DataRow.ItemArray[2].ToString();

            // Dynamically format the URL of the API using Country code and Postal code.
            string url = $"http://api.zippopotam.us/{countryCode}/{postalCode}";

            // StopWatch for computing elapsed time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Invoke the API
            var client = new RestClient(url);
            var response = client.Execute(new RestRequest());

            // Compute the time elapsed in milliseconds
            long timeTakenInMilliseconds = stopwatch.ElapsedMilliseconds;

            // Ensure that the call is success 200 (HttpStatusCode.OK) additionally ensure return data type is JSON.
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, "Error fetching API :" + url);
            Assert.AreEqual(response.ContentType, "application/json", "Expected context type is JSON");

            // Ensure the time taken for API invocation is less that a second
            Assert.IsTrue(timeTakenInMilliseconds < 1000, "Time taken to fetch API data exceeds one second. Time taken in millisec : " + timeTakenInMilliseconds);

            // Deserialize the returned JSON string to Country object.
            var country = JsonConvert.DeserializeObject<Country>(response.Content);

            // Ensure the Place name what we fetched from API is same as what we received from CSV
            string placeNameFromApi = country.Places.First().PlaceName;
            Assert.AreEqual(placeName, placeNameFromApi, $"Mismatch in place name for country code:{countryCode}, postal code : {postalCode}");
        }

        #endregion

    }

}
