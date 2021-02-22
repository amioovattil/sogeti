using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SogetiTests.TestCase2
{

    /// <summary>
    /// Test automation to perform contact us form inside the Automation page
    /// </summary>
    [TestClass]
    public class ContactUsTests
    {

        #region Test methods

        /// <summary>
        /// Test automation to perform contact us form inside the Automation page using Chrome
        /// </summary>
        [TestMethod]
        public void ContactUsTestInChrome()
        {
            PerformContactUsTest(BrowserType.Chrome);
        }

        /// <summary>
        /// Test automation to perform contact us form inside the Automation page using Edge
        /// </summary>
        [TestMethod]
        public void ContactUsTestInEdge()
        {
            PerformContactUsTest(BrowserType.Edge);
        }

        #endregion

        #region Private methods

        private void PerformContactUsTest(BrowserType browserType)
        {
            // Initialize web driver
            IWebDriver webDriver = DriverUtilities.CreateDriver(browserType);
            Assert.IsNotNull(webDriver, "Could not acquire driver for :" + browserType);

            webDriver.Navigate().GoToUrl(LocatorHelper.HOME_PAGE_URL);

            // Accept all cookies
            IWebElement acceptAllCookiesButton = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AcceptAllCookies);
            acceptAllCookiesButton.Click();

            // Navigate to services and automation page
            IWebElement serviceMainMenu = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.ServiceMainMenu);
            serviceMainMenu.Click();

            IWebElement automationLink = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AutomationSubMenu);
            automationLink.Click();

            // Suffix to generate random texts
            string suffix = DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss");

            // Generate random texts for required fields
            IWebElement firstName = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.FirstName);
            firstName.SendKeys("FirstName" + suffix);

            IWebElement lastName = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.LastName);
            lastName.SendKeys("LastName" + suffix);

            IWebElement email = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.EMail);
            email.SendKeys(suffix + "@a.com");

            IWebElement phone = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.Phone);
            phone.SendKeys("0049");

            IWebElement country = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.Country);
            country.SendKeys("Germany");

            IWebElement message = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.Message);
            message.SendKeys("some message" + suffix);

            // Click on Agree checkbox
            IWebElement agreement = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.Agreement);
            agreement.Click();


            // Note : Captcha stops the test run here.
            // Captcha has been introduced to stop the automated usage of website hence this does not let us to continue further.
            // Please see the following pseudo code.

            //IWebElement captcha = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.Captcha);

            //IWebElement submit = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.Submit);
            //submit.Click();

            //IWebElement thankYouDiv = LocatorHelper.FindContactUsControl(webDriver, ContactUsLocatorName.ThankYou);
            //if (thankYouDiv == null || !thankYouDiv.Text.Contains("Thank you for contacting us."))
            //    Assert.Fail("Expected 'Thank you message' missing on Contact Us submit action");


            // Exit the driver
            DriverUtilities.DisposeDriver(webDriver);
        }

        #endregion

    }
}
