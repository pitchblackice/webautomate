
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;


namespace Selenium_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Users\\uncle\\webdriver");
            //IWebDriver driver = new FirefoxDriver("C:\\Users\\uncle\\webdriver");


            // This will open up the URL
            driver.Url = "https://www.academymortgage.com/";
            driver.Manage().Window.Maximize();
            BasePage whoWeAre = new BasePage(driver, "Who We Are", "AboutUs", "WhoWeAre");
            BasePage whatSetsUsApart = new BasePage(driver, "What Sets Us Apart", "AboutUs", "WhatSetsUsApart");
            BasePage howWeMeasureSuccess = new BasePage(driver, "How We Measure Success", "AboutUs", "HowWeMeasureSuccess");
            BasePage whereWeBegan = new BasePage(driver, "Where We Began", "AboutUs", "WhereWeBegan");
            ContactUs contactUs = new ContactUs(driver);
            whoWeAre.LoadPage();
            whatSetsUsApart.LoadPage();
            howWeMeasureSuccess.LoadPage();
            whereWeBegan.LoadPage();
            contactUs.LoadPage();
            contactUs.FillForm();
            driver.Close();
            driver.Quit();

        }
    }
}