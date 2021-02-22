using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SogetiTests.TestCase1
{

    /// <summary>
    /// Test case to verify the Service main menu and automation link selection.
    /// </summary>
    [TestClass]
    public class ServiceSelectionTests
    {

        #region Test methods

        /// <summary>
        /// Test case to verify the Service main menu and automation link selection in Chrome.
        /// </summary>
        [TestMethod]
        public void ServiceSelectionTestInChrome()
        {
            PerformServiceSelectionTest(BrowserType.Chrome);
        }

        /// <summary>
        /// Test case to verify the Service main menu and automation link selection in Edge.
        /// </summary>
        [TestMethod]
        public void ServiceSelectionTestInEdge()
        {
            PerformServiceSelectionTest(BrowserType.Edge);
        }

        #endregion

        #region Private methods

        private void PerformServiceSelectionTest(BrowserType browserType)
        {
            // Initialize web driver
            IWebDriver webDriver = DriverUtilities.CreateDriver(browserType);
            Assert.IsNotNull(webDriver, "Could not acquire driver for :" + browserType);

            webDriver.Navigate().GoToUrl(LocatorHelper.HOME_PAGE_URL);

            // Accept all cookies
            IWebElement acceptAllCookiesButton = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AcceptAllCookies);
            acceptAllCookiesButton.Click();

            // Click on Service in main menu
            IWebElement serviceMainMenu = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.ServiceMainMenu);
            serviceMainMenu.Click();

            // Click on Automation under Services
            IWebElement automationLink = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AutomationSubMenu);
            automationLink.Click();

            // Verify the Automation title in tab window
            Assert.AreEqual(webDriver.Title, "Automation", "Missing the title 'Automation'");

            // Verify the Automation title inside the page
            IWebElement automationHeader = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AutomationHeaderText);
            Assert.AreEqual(automationHeader.Text, "Automation", "Missing the header text 'Automation'");

            // Ensure Services and Automation links are selected
            serviceMainMenu = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.ServiceMainMenu);
            serviceMainMenu.Click();

            string classAttributValue = serviceMainMenu.GetAttribute("class");
            if (!classAttributValue.Contains("selected has-children  expanded level2 hover"))
                Assert.Fail("Service menu not selected and expanded");

            IWebElement automationLinkParent = LocatorHelper.FindServicePageControl(webDriver, ServicePageLocatorName.AutomationSubMenuParentLI);
            Assert.IsNotNull(automationLinkParent, "Automation sub menu is not selected");
 

            // Close the web driver
            DriverUtilities.DisposeDriver(webDriver);
        }

        #endregion

    }
}
