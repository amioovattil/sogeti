using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using EdgeOptions = Microsoft.Edge.SeleniumTools.EdgeOptions;
using EdgeDriver = Microsoft.Edge.SeleniumTools.EdgeDriver;

namespace SogetiTests
{

    /// <summary>
    /// Utility class to initialize web drivers
    /// </summary>
    internal class DriverUtilities
    {

        #region Internal methods

        /// <summary>
        /// This method create a driver based on BrowserType.
        /// </summary>
        /// <param name="browserType"></param>
        /// <returns></returns>
        internal static IWebDriver CreateDriver(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
                return CreateChromeDriver();
            else if (browserType == BrowserType.Edge)
                return CreateEdgeDriver();
            else
                throw new ArgumentException("Unexpected value for 'browserType'");
        }

        /// <summary>
        /// Closes the web driver.
        /// </summary>
        /// <param name="driver"></param>
        internal static void DisposeDriver(IWebDriver driver)
        {
            if (driver != null)
                driver.Quit();
        }

        #endregion

        #region Private methods

        private static IWebDriver CreateChromeDriver()
        {
            try
            {
                ChromeDriver chromeDriver = new ChromeDriver();

                if (chromeDriver != null)
                {
                    chromeDriver.Manage().Window.Maximize();
                    chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                }

                return chromeDriver;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return null;
            }
        }

        private static IWebDriver CreateEdgeDriver()
        {
            try
            {
                string browserLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"; // Please adjust the path if needed

                EdgeOptions options = new EdgeOptions();
                options.UseChromium = true;
                //options.AddArgument("headless");
                options.BinaryLocation = browserLocation;

                EdgeDriver edgeDriver = new EdgeDriver(options);

                if (edgeDriver != null)
                {
                    edgeDriver.Manage().Window.Maximize();
                    edgeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                }

                return edgeDriver;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return null;
            }
        }

        #endregion

    }


}
