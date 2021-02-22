using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SogetiTests.TestCase3
{

    /// <summary>
    /// Test automation code to ensure the country links working.
    /// </summary>
    [TestClass]
    public class CountryTests
    {

        #region Test methods

        /// <summary>
        /// Test automation code to ensure the country links working in chrome.
        /// </summary>
        [TestMethod]
        public void CountryTestInChrome()
        {
            PerformCountryTest(BrowserType.Chrome);
        }

        /// <summary>
        /// Test automation code to ensure the country links working in edge.
        /// </summary>
        [TestMethod]
        public void CountryTestInEdge()
        {
            PerformCountryTest(BrowserType.Edge);
        }

        #endregion

        #region Private methods

        private void PerformCountryTest(BrowserType browserType)
        {
            // Initialize the web driver
            IWebDriver webDriver = DriverUtilities.CreateDriver(browserType);
            Assert.IsNotNull(webDriver, "Could not acquire driver for :" + browserType);

            webDriver.Navigate().GoToUrl(LocatorHelper.HOME_PAGE_URL);

            // Accept all cookies
            IWebElement acceptAllCookiesButton = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AcceptAllCookies);
            acceptAllCookiesButton.Click();

            // Open the countries drop down
            IWebElement dropDown = LocatorHelper.FindHomePageControl(webDriver, HomePageLocatorName.CountryDropDown);
            dropDown.Click();

            // Fetch all country web elements
            IWebElement countryList = LocatorHelper.FindHomePageControl(webDriver, HomePageLocatorName.CountryList);
            IEnumerable<IWebElement> countryEntries = LocatorHelper.FindAllCountries(webDriver, countryList);

            string firstWindowHandle = webDriver.WindowHandles.First();

            // Iterate each country web element (anchor)
            foreach (IWebElement countryEntry in countryEntries)
            {
                // Open a new Tab window for the country
                countryEntry.Click();

                string countryName = countryEntry.Text;

                // Ensure a new Tab window has been opened
                string lastWindowHandle = webDriver.WindowHandles.Last();
                Assert.AreNotEqual(firstWindowHandle, lastWindowHandle, "Could not open link for :" + countryName);

                // Switch the driver to newly opened tab window
                webDriver.SwitchTo().Window(lastWindowHandle);

                // Accept all cookies in the newly opened tab window
                acceptAllCookiesButton = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AcceptAllCookies);
                if (acceptAllCookiesButton != null)
                    acceptAllCookiesButton.Click();

                // Ensure that the newly opened tab window page has a valid Sogeti logo.
                IWebElement logo = LocatorHelper.FindHomePageControl(webDriver, HomePageLocatorName.SogetiLogo);
                if (logo == null)
                    logo = LocatorHelper.FindHomePageControl(webDriver, HomePageLocatorName.SogetiLogoNetherlands);

                Assert.IsNotNull(logo, "Page not working for :" + countryName);

                // Close the newly opened tab window
                webDriver.Close();

                // Switch the driver back to the original page
                webDriver.SwitchTo().Window(firstWindowHandle);
            }

            // Close the driver.
            DriverUtilities.DisposeDriver(webDriver);
        }

        #endregion

    }
}
