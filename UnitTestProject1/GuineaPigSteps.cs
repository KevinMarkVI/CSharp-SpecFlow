using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [Binding]
    public class GuineaPigSteps
    {
        public IWebDriver driver;
        public String pageTitle;

        [Before]
        public void Before()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Version, "46");
            capabilities.SetCapability(CapabilityType.Platform, "OS X 10.10");
            capabilities.SetCapability("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            capabilities.SetCapability("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
            capabilities.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities, TimeSpan.FromSeconds(600));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }


        [Given(@"I am on the Guinea Pig Website")]
        public void GivenIAmOnTheGuineaPigWebsite()
        {
            driver.Navigate().GoToUrl("https://saucelabs.com/test/guinea-pig");
        }
        
        [When(@"I check the title")]
        public void WhenICheckTheTitle()
        {
            pageTitle = driver.Title;
        }
        
        [Then(@"the title should be what I expect")]
        public void ThenTheTitleShouldBeWhatIExpect()
        {
            Assert.AreEqual(pageTitle, "I am a page title - Sauce Labs");
        }

        [After]
        public void After()
        {
            bool passed = ScenarioContext.Current.TestError == null;
            //bool passed = true;
            ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            driver.Dispose();
        }
    }
}
