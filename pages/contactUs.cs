using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

class ContactUs : BasePage {
    public BaseElement TextFieldName;
    public BaseElement TextFieldEmail;
    public BaseElement TextFieldPhone;
    public BaseElement TextFieldCity;
    public BaseElement ListState;
    public BaseElement TextFieldZipCode;
    public BaseElement ListLoan;
    public BaseElement TextAreaMessage;
    public BaseElement TextFieldLoanOfficer;
    public BaseElement ButtonCloseChat;
    private const string localTitle = "Contact Us";
    private const string localTopNav = "AboutUs";
    private const string localSubNav = "ContactUs";
    public ContactUs(IWebDriver localDriver) : base(localDriver, localTitle, localTopNav, localSubNav)
    {
        TextFieldName = new BaseElement(localDriver, "id", "Textbox-1");
        TextFieldEmail = new BaseElement(localDriver, "id", "Textbox-2");
        TextFieldPhone = new BaseElement(localDriver, "id", "Textbox-3");
        TextFieldCity = new BaseElement(localDriver, "id", "Textbox-4");
        ListState = new BaseElement(localDriver, "id", "Dropdown-1");
        TextFieldZipCode = new BaseElement(localDriver, "id", "Textbox-5");
        ListLoan = new BaseElement(localDriver, "id", "Dropdown-2");
        TextAreaMessage = new BaseElement(localDriver, "id", "Textarea-1");
        TextFieldLoanOfficer = new BaseElement(localDriver, "id", "Textbox-6");
        ButtonCloseChat = new BaseElement(localDriver, "id", "closeChat");
    }

    public void FillForm() {
        TextFieldName.SetText("Richard Simpson");
        TextFieldEmail.SetText("richard.simpson256@gmail.com");
        TextFieldPhone.SetText("(435)503-7465");
        TextFieldCity.SetText("Spanish Fork");
        ButtonCloseChat.ClickIfExists();
        ListState.SelectByValue("Utah");
        TextFieldZipCode.SetText("84660");
        base.ScrollToPoint(500);
        ButtonCloseChat.ClickIfExists();
        ListLoan.SelectByValue("Yes!");
        TextAreaMessage.SetText("I am interested in applying for a loan. Please respond when you have time to richard.simpson256@gmail.com. Thanks!");
        TextFieldLoanOfficer.SetText("The Best One You Have");
        Thread.Sleep(5000);
    }
}