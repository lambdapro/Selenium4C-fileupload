using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FirstTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            String[] file = { "image.png"};  // Uploaded files list here
            var chromeOptions = new ChromeOptions();
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("lambda:userFiles", file);
            ltOptions.Add("build", "your build name");
            ltOptions.Add("name", "your test name");
            ltOptions.Add("platformName", "Windows 10");
            String user=Environment.GetEnvironmentVariable("LT_USERNAME");
            String key=Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
            ltOptions.Add("user", user); 
            ltOptions.Add("accessKey", key);
            chromeOptions.AddAdditionalOption("LT:Options", ltOptions);
            //chromeOptions.AddAdditionalOption("lambda:userFiles",file);
            IWebDriver driver = new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), chromeOptions);
            //Thread.Sleep(2000);
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/upload");

            IWebElement upload = driver.FindElement(By.Id("file-upload"));
            upload.SendKeys("C:\\Users\\ltuser\\Downloads\\image.png");

            driver.FindElement(By.Id("file-submit")).Click();
 
            driver.Quit(); //really important statement for preventing your test execution from a timeout.
        }
        
    }
}
