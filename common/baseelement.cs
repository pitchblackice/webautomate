using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

class BaseElement {
    public const string Xpath = "xpath";
    public const string Id = "id";
    public const string Class = "class";
    public string Type;
    public string Value;
    public IWebDriver driver;
    private By localBy;
    public BaseElement(IWebDriver localDriver, string localType, string localValue) {
        Type = localType;
        Value = localValue;
        driver = localDriver;
    }

    public By ByLocator(string type, string value) {
        if (type == Xpath) {
            localBy = By.XPath(value);
        }
        if (type == Id) {
            localBy = By.Id(value);
        }
        if (type == Class) {
            localBy = By.ClassName(value);
        }
        return localBy;
    }

    public void WaitClick(int waitTime) {
        WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
        w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByLocator(Type, Value)));
        Element().Click();
    }

    public IWebElement Element() {
        IWebElement localElement = driver.FindElement(ByLocator(Type, Value));
        return localElement;
    }

    public void SelectByText(string text) {
        var selectElement = new SelectElement(Element());
        selectElement.SelectByText(text);
    }

    public void SelectByValue(string text)
    {
        var selectElement = new SelectElement(Element());
        selectElement.SelectByValue(text);
    }

    public void SelectByIndex(int index)
    {
        var selectElement = new SelectElement(Element());
        selectElement.SelectByIndex(index);
    }

    public void SetText(string text) {
        Element().SendKeys(text);
    }

    public void ScrollToElement() {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", Element());
    }
    public static IWebElement FindElementIfExists(IWebDriver driver, By by)
    {
        var elements = driver.FindElements(by);
        return (elements.Count >= 1) ? elements.First() : null;
    }

    public void ClickIfExists()
    {
        var localElement = FindElementIfExists(driver, ByLocator(Type, Value));
        if (localElement != null)
        {
            Element().Click();
        }
    }
}
