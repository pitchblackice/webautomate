using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

public class BasePage { 
    public string Title;
    private string topNav;
    private string subNav;
    private NavBar navBar;
    private IWebDriver driver;
    public BasePage(IWebDriver localDriver, string localTitle, string localTopNav, string localSubNav) {
        driver = localDriver;
        Title = localTitle;
        topNav = localTopNav;
        subNav = localSubNav;
        navBar = new NavBar(driver);
    }

    // LoadPage loads the page by clicking on the navigation links and then verifies the page is loaded by checking the page title
    public void LoadPage() {
        navBar.TopNav[topNav].WaitClick(10);
        navBar.SubNav[subNav].WaitClick(10);
        Assert.That(driver.Title, Contains.Substring(Title), "Expected page title does not match actual");
        // Sleep added only to allow time to see what page is loaded
        Thread.Sleep(2000);
    }

    public void ScrollToBottom() {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    }

    public void ScrollToTop() {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollTo(0, 0)");
    }

    public void ScrollToPoint(int lines) {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollTo(0," + lines + ")");
    }
}
