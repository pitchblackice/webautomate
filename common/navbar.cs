using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

class NavBar {
    public IDictionary<string, BaseElement> TopNav = new Dictionary<string, BaseElement>();
    public IDictionary<string, BaseElement> SubNav = new Dictionary<string, BaseElement>();
    public const string AboutUs = "cm-dropdown1";
    public const string LoanProgram = "cm-dropdown2";
    public NavBar(IWebDriver driver) {
        TopNav.Add("AboutUs", new BaseElement(driver, "id", "cm-dropdown1"));
        TopNav.Add("LoanProgram", new BaseElement(driver, "id", "cm-dropdown2"));
        SubNav.Add("WhoWeAre", new BaseElement(driver, "xpath", "//a[@href='/about-us/who-we-are']"));
        SubNav.Add("WhatSetsUsApart", new BaseElement(driver, "xpath", "//a[@href='/about-us/what-sets-us-apart']"));
        SubNav.Add("HowWeMeasureSuccess", new BaseElement(driver, "xpath", "//a[@href='/about-us/how-we-measure-success']"));
        SubNav.Add("WhereWeBegan", new BaseElement(driver, "xpath", "//a[@href='/about-us/where-we-began']"));
        SubNav.Add("ContactUs", new BaseElement(driver, "xpath", "//a[@href='/about-us/contact-us']"));
    }
}
