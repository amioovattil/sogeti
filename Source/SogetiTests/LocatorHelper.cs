using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SogetiTests
{

    /// <summary>
    /// Utility class to fetch various web elements.
    /// </summary>
    internal class LocatorHelper
    {

        #region Fields

        internal static string HOME_PAGE_URL = "https://www.sogeti.com/";

        #endregion

        #region Internal methods


        /// <summary>
        /// Return a web element from ServicePage for the supplied ServicePageLocatorName.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="locatorName"></param>
        /// <returns></returns>
        internal static IWebElement FindServicePageControl(IWebDriver webDriver, ServicePageLocatorName locatorName)
        {
            IEnumerable<IWebElement> elementsFound = null;

            if (locatorName == ServicePageLocatorName.AcceptAllCookies)
                elementsFound = webDriver.FindElements(By.CssSelector("button[class='acceptCookie']"));
            else if (locatorName == ServicePageLocatorName.ServiceMainMenu)
                elementsFound = webDriver.FindElements(By.CssSelector("li[data-levelname='level2']"));

            else if (locatorName == ServicePageLocatorName.AutomationSubMenu)
                elementsFound = webDriver.FindElements(By.CssSelector("a[href='https://www.sogeti.com/services/automation/']"));
            else if (locatorName == ServicePageLocatorName.AutomationSubMenuParentLI)
                elementsFound = webDriver.FindElements(By.CssSelector("li[class='selected  current expanded']"));
            
            else if (locatorName == ServicePageLocatorName.AutomationHeaderText)
                elementsFound = webDriver.FindElements(By.CssSelector("h1"));

            if (elementsFound != null && elementsFound.Count() > 0)
                return elementsFound.First();
            else
                return null;
        }

        /// <summary>
        /// Return the web element from the ContactUs inside AutomationPage for the supplied ContactUsLocatorName.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="locatorName"></param>
        /// <returns></returns>
        internal static IWebElement FindContactUsControl(IWebDriver webDriver, ContactUsLocatorName locatorName)
        {
            IEnumerable<IWebElement> elementsFound = null;

            if (locatorName == ContactUsLocatorName.FirstName)
                elementsFound = webDriver.FindElements(By.Id("4ff2ed4d-4861-4914-86eb-87dfa65876d8"));
            else if (locatorName == ContactUsLocatorName.LastName)
                elementsFound = webDriver.FindElements(By.Id("11ce8b49-5298-491a-aebe-d0900d6f49a7"));

            else if (locatorName == ContactUsLocatorName.EMail)
                elementsFound = webDriver.FindElements(By.Id("056d8435-4d06-44f3-896a-d7b0bf4d37b2"));
            else if (locatorName == ContactUsLocatorName.Phone)
                elementsFound = webDriver.FindElements(By.Id("755aa064-7be2-432b-b8a2-805b5f4f9384"));
            
            else if (locatorName == ContactUsLocatorName.Country)
                elementsFound = webDriver.FindElements(By.Id("e74d82fb-949d-40e5-8fd2-4a876319c45a"));
            else if (locatorName == ContactUsLocatorName.Message)
                elementsFound = webDriver.FindElements(By.Id("88459d00-b812-459a-99e4-5dc6eff2aa19"));
            
            else if (locatorName == ContactUsLocatorName.Agreement)
                elementsFound = webDriver.FindElements(By.Name("__field_123935"));
            else if (locatorName == ContactUsLocatorName.Captcha)
                elementsFound = webDriver.FindElements(By.XPath("//*[@id='recaptcha - anchor']"));
            
            else if (locatorName == ContactUsLocatorName.Submit)
                elementsFound = webDriver.FindElements(By.Id("06838eea-8980-4305-83d0-42236fb4d528"));
            else if (locatorName == ContactUsLocatorName.ThankYou)
                elementsFound = webDriver.FindElements(By.CssSelector("div[class='Form__Status__Message Form__Success__Message']"));

            if (elementsFound != null && elementsFound.Count() > 0)
                return elementsFound.First();
            else
                return null;
        }


        /// <summary>
        /// Return the web element from the HomePage for the supplied HomePageLocatorName.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="locatorName"></param>
        /// <returns></returns>
        internal static IWebElement FindHomePageControl(IWebDriver webDriver, HomePageLocatorName locatorName)
        {
            IEnumerable<IWebElement> elementsFound = null;

            if (locatorName == HomePageLocatorName.CountryDropDown)
                elementsFound = webDriver.FindElements(By.CssSelector("div[class='sprite-header sprite-global-arrowdown']"));
            else if (locatorName == HomePageLocatorName.CountryList)
                elementsFound = webDriver.FindElements(By.CssSelector("div[class='country-list']"));
            else if (locatorName == HomePageLocatorName.SogetiLogo)
                elementsFound = webDriver.FindElements(By.CssSelector("img[alt='Sogeti Logo']"));
            else if (locatorName == HomePageLocatorName.SogetiLogoNetherlands)
                elementsFound = webDriver.FindElements(By.CssSelector("img[alt='Home']"));

            if (elementsFound != null && elementsFound.Count() > 0)
                return elementsFound.First();
            else
                return null;
        }

        /// <summary>
        /// Returns all the anchor elements for countries
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="countryList"></param>
        /// <returns></returns>
        internal static IEnumerable<IWebElement> FindAllCountries(IWebDriver webDriver, IWebElement countryList)
        {
            return countryList.FindElements(By.CssSelector("a"));
        }


        #endregion
    }
}
