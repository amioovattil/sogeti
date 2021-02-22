using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SogetiTests
{

    /// <summary>
    /// Vasarious browsers supported
    /// </summary>
    internal enum BrowserType
    {
        Chrome,
        Edge
    }

    /// <summary>
    /// Locators required for Service page
    /// </summary>
    internal enum ServicePageLocatorName
    {
        AcceptAllCookies,
        ServiceMainMenu,
        AutomationSubMenu,
        AutomationHeaderText,
        AutomationSubMenuParentLI
    }

    /// <summary>
    /// Locators required for ContactUs inside AutomationPage
    /// </summary>
    internal enum ContactUsLocatorName
    {
        FirstName,
        LastName,
        EMail,
        Phone,
        Country,
        Message,
        Agreement,
        Captcha,
        Submit,
        ThankYou
    }

    /// <summary>
    /// Locators required for HomePage
    /// </summary>
    internal enum HomePageLocatorName
    {
        CountryDropDown,
        CountryList,
        SogetiLogo,
        SogetiLogoNetherlands
    }
}
