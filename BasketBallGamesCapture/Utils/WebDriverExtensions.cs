﻿namespace BasketBallGamesCapture.Utils
{
    using OpenQA.Selenium;
    using System;
    using System.Diagnostics.Contracts;
    using System.Drawing.Imaging;

    public static class WebDriverExtensions
    {
        public static IWebDriver AdjustWindowSizeAndLocation(this IWebDriver webDriver)
        {
            Contract.Assert(webDriver != null, "The web driver cannot be null.");

            webDriver.Manage().Window?.Maximize();
            
            return webDriver;
        }

        public static IWebDriver ClearCookies(this IWebDriver webDriver)
        {
            Contract.Assert(webDriver != null, "The web driver cannot be null.");

            ICookieJar cookieJar = webDriver.Manage().Cookies;

            if (cookieJar != null)
            {
                cookieJar.DeleteAllCookies();
            }

            return webDriver;
        }

        public static IWebDriver SetupTimeout(this IWebDriver webDriver,
                                              double ScriptExecuteTimeoutSeconds,
                                              double PageLoadTimeoutSeconds)
        {
            Contract.Assert(webDriver != null, "The web driver cannot be null.");
            Contract.Assert(ScriptExecuteTimeoutSeconds >= 0, "The script execute timeout is invalid.");
            Contract.Assert(PageLoadTimeoutSeconds >= 0, "The page load timeout is invalid.");

            ITimeouts timeouts = webDriver.Manage().Timeouts();

            if (timeouts != null)
            {
                timeouts.SetScriptTimeout(TimeSpan.FromSeconds(ScriptExecuteTimeoutSeconds));
                timeouts.SetPageLoadTimeout(TimeSpan.FromSeconds(PageLoadTimeoutSeconds));
            }

            return webDriver;
        }

        public static string TakeScreenShot(this IWebDriver webDriver,
                                                string imageFileFullPath,
                                                ImageFormat imageFormat)
        {
            Contract.Assert(webDriver != null, "The web driver cannot be null.");

            ITakesScreenshot screenShotExecutor = webDriver as ITakesScreenshot;

            if (screenShotExecutor != null)
            {
                Screenshot screenshot = screenShotExecutor.GetScreenshot();

                imageFileFullPath = ProcessFilePath(imageFileFullPath, imageFormat.ToString());

                screenshot.SaveAsFile(imageFileFullPath, imageFormat);
            }

            return imageFileFullPath;
        }

        private static string ProcessFilePath(string fileFullPath, string fileExtensionName)
        {
            string fileFullPathWithExtensionName = string.Empty;

            if (!fileFullPath.EndsWith($".{ fileExtensionName }", StringComparison.OrdinalIgnoreCase))
            {
                fileFullPathWithExtensionName = $"{ fileFullPath }.{ fileExtensionName }";
            }
            else
            {
                fileFullPathWithExtensionName = fileFullPath;
            }

            return fileFullPathWithExtensionName.Trim();
        }

        public static double FractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (double)a / b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (double)b / c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }
    }
}
