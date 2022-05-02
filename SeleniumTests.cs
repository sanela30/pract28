using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using EC= SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace pract28
{
    internal class SeleniumTests
    {
        IWebDriver driver;

        WebDriverWait wait;

        private string TestData_Email = UsefulFunctions.RandomEmail();
        private string TestData_Password= UsefulFunctions.RandomPassword();


        [Test]
        public void TestHomePage()
        {

            IWebElement logo = driver.FindElement(By.ClassName("logo"));
            if (logo.Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void TestSignIn()
        {

            ClickOnSignINLInk();
            IWebElement validateEmail = driver.FindElement(By.Name("email"));

            if (validateEmail.Displayed && validateEmail.Enabled)
            {
                validateEmail.SendKeys(TestData_Email);
            }
            IWebElement validatePasswd = driver.FindElement(By.Name("passwd"));
            if (validatePasswd.Displayed && validatePasswd.Enabled)
            {
                validatePasswd.SendKeys(TestData_Password);
            }
            IWebElement submitLogin = driver.FindElement(By.Name("SubmitLogin"));
            if (submitLogin.Displayed && submitLogin.Enabled)
            {
                submitLogin.Click();
            }

        }
        [Test]
        public void TestRegistration()
        {
            ClickOnSignINLInk();

            IWebElement createBUtton = driver.FindElement(By.Name("SubmitCreate"));
            if (createBUtton.Displayed && createBUtton.Enabled)
            {
                IWebElement createEmail = driver.FindElement(By.Name("email_create"));
                if (createEmail.Displayed && createEmail.Enabled)
                {
                    createEmail.SendKeys(TestData_Email);
                }

                createBUtton.Click();
            }
            //System.Threading.Thread.Sleep(2000);




            IWebElement form_firstName = wait.Until(
                EC.ElementIsVisible(By.Name("customer_firstname")));

           // IWebElement form_firstName = driver.FindElement(By.Name("customer_firstname"));
            if (form_firstName.Displayed && form_firstName.Enabled)
            {
                form_firstName.SendKeys("ProbnoIme");

                IWebElement form_lastName = driver.FindElement(By.Name("customer_lastname"));
                if (form_lastName.Displayed && form_lastName.Enabled)
                {
                    form_lastName.SendKeys("ProbnoPrezime");
                }

                IWebElement form_password = driver.FindElement(By.Name("passwd"));
                if (form_password.Displayed && form_password.Enabled)
                {
                    form_password.SendKeys(TestData_Password);
                }

                IWebElement form_addressFirstName = driver.FindElement(By.Name("firstname"));
                if (form_addressFirstName.Displayed && form_addressFirstName.Enabled)
                {
                    form_addressFirstName.Clear();
                    form_addressFirstName.SendKeys("ProbnoIme");
                }
                IWebElement form_addressLastName = driver.FindElement(By.Name("lastname"));
                if (form_addressLastName.Displayed && form_addressLastName.Enabled)
                {
                    form_addressLastName.Clear();
                    form_addressLastName.SendKeys("ProbnoPrezime");
                }
                System.Threading.Thread.Sleep(2000);

                IWebElement form_addressAdress = driver.FindElement(By.Name("address1"));
                if (form_addressAdress.Displayed && form_addressAdress.Enabled)
                {
                    form_addressAdress.SendKeys("Neka Adresa 35");
                }
                IWebElement form_addressCity = driver.FindElement(By.Name("city"));
                if (form_addressCity.Displayed && form_addressCity.Enabled)
                {
                    form_addressCity.SendKeys("Grad");
                }
                 // System.Threading.Thread.Sleep(5000);

                IWebElement form_addressState = driver.FindElement(By.Name("id_state"));
                wait.Until(EC.ElementExists(By.XPath("//option[@value='50']")));

                if (form_addressState.Enabled)
                {
                    SelectElement state = new SelectElement(form_addressState);
                    state.SelectByText("Hawaii");
                    //state.SelectByValue("11");*/
                }

                IWebElement form_PostCode = driver.FindElement(By.Name("postcode"));
                if (form_PostCode.Displayed && form_PostCode.Enabled)
                {
                    form_PostCode.SendKeys("12345");
                }
                IWebElement form_addressCountry = driver.FindElement(By.Name("id_country"));
                if (form_addressCountry.Displayed && form_addressCountry.Enabled)
                {
                    SelectElement country = new SelectElement(form_addressCountry);
                    country.SelectByText("United States");
                    //country.SelectByValue("-");
                }
                IWebElement form_Phone_mobile = driver.FindElement(By.Name("phone_mobile"));
                if (form_Phone_mobile.Displayed && form_Phone_mobile.Enabled)
                {
                    form_Phone_mobile.SendKeys("5689347");
                }
                IWebElement form_alias = driver.FindElement(By.Name("alias"));
                if (form_alias.Displayed && form_alias.Enabled)
                {
                    form_alias.Clear();
                    form_alias.SendKeys("MojaAdresa");
                }
                IWebElement submitAccount = driver.FindElement(By.Name("submitAccount"));
                if (submitAccount.Displayed && submitAccount.Enabled)
                {
                    submitAccount.Click();
                }

                System.Threading.Thread.Sleep(9000);
            }

        }
        public void ClickOnSignINLInk()
        {
            IWebElement sigIn = wait.Until(EC.ElementIsVisible(By.LinkText("Sign in")));
            if (sigIn.Displayed && sigIn.Enabled)
            {
                sigIn.Click();
            }
        }


        [SetUp]
        public void SetUp()
        {
         
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver,new TimeSpan(0,0, 30));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }


    }
}
