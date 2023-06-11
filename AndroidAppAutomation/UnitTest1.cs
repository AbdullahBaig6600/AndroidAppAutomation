using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace AndroidAppAutomation
{
    public class Tests
    {
        public static AndroidDriver<AndroidElement> driver;

        [Test]
        public void AndroidNativeApp()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("deviceName", "SLVNW19C06008295");
            options.AddAdditionalCapability("platformVersion", "10.0");
            options.AddAdditionalCapability("platformName", "Android");
            options.AddAdditionalCapability("appPackage", "com.android.calculator2");
            options.AddAdditionalCapability("appActivity", "com.android.calculator2.Calculator");

            driver = new AndroidDriver<AndroidElement>(
                new System.Uri("http://127.0.0.1:4723/wd/hub"), options);

            Thread.Sleep(2000);

            driver.FindElement(By.Id("com.android.calculator2:id/digit_5")).Click();
            driver.FindElement(By.Id("com.android.calculator2:id/op_add")).Click();
            driver.FindElement(By.Id("com.android.calculator2:id/digit_6")).Click();
            driver.FindElement(By.Id("com.android.calculator2:id/eq")).Click();

            driver.CloseApp();

        }

        [Test]
        public void AndroidWebApp()
        {
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("deviceName", "SLVNW19C06008295");
            options.AddAdditionalCapability("platformVersion", "10.0");
            options.AddAdditionalCapability("platformName", "Android");
            options.AddAdditionalCapability("browserName", "Chrome");

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = false;
            options.GetMergeResult(chromeOptions);

            var driver = new RemoteWebDriver(
                new System.Uri("http://127.0.0.1:4723/wd/hub"), options);

            Thread.Sleep(3000);
            driver.Url = "https://adactinhotelapp.com/";
            Thread.Sleep(5000);
            driver.FindElementById("username").SendKeys("baigxo12345");
            driver.FindElementById("password").SendKeys("baigxo12345");
            driver.FindElementById("login").Click();
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}