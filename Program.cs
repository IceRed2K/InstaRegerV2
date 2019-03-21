using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Test2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FirefoxDriverService service =
                FirefoxDriverService.CreateDefaultService(@"GeckoDriver19", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            // Proxy
//            FirefoxOptions firefoxOptions = new FirefoxOptions();
//            firefoxOptions.SetPreference("network.proxy.type", 1);
//            firefoxOptions.SetPreference("network.proxy.socks", "37.203.246.144");
//            firefoxOptions.SetPreference("network.proxy.socks_port", 61011);
            //IWebDriver driver = new FirefoxDriver(firefoxOptions);


            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://www.instagram.com/");


            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;

            Thread.Sleep(3500);
            string loginId =
                (string) js.ExecuteScript(
                    "var item = document.getElementsByName('emailOrPhone'); return(item[0].getAttribute('id'));");
            string fullname =
                (string) js.ExecuteScript(
                    "var item = document.getElementsByName('fullName'); return(item[0].getAttribute('id'));");
            string username =
                (string) js.ExecuteScript(
                    "var item = document.getElementsByName('username'); return(item[0].getAttribute('id'));");
            string password =
                (string) js.ExecuteScript(
                    "var item = document.getElementsByName('password'); return(item[0].getAttribute('id'));");

            Console.WriteLine($"LOGIN: {loginId} , fullname: {fullname} , username: {username} , password: {password}");

            SetData(driver, js, loginId, username, fullname, password);
        }


        static void SetData(IWebDriver driver, IJavaScriptExecutor js, string loginId, string username, string fullname,
            string password)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Id(loginId)).SendKeys("clonemyte31FA@gmail.com");
            Thread.Sleep(500);
            driver.FindElement(By.Id(fullname)).SendKeys("Love Goodlike");
            Thread.Sleep(700);
            driver.FindElement(By.Id(username)).SendKeys("Clone3ry913");
            Thread.Sleep(200);
            driver.FindElement(By.Id(password)).SendKeys("Squeary491");

            Thread.Sleep(1500);
            string btnClassName = (string) js.ExecuteScript(
                "var buttons = document.getElementsByTagName('button'); for (var i = 0; i < buttons.length; i++) {  if (buttons[i].innerText === 'Регистрация') { document.getElementById(buttons[i].click()); return (buttons[i].getAttribute('class')); } }");

            Console.WriteLine("Button Class: " + btnClassName);

            Thread.Sleep(1000);
            string result = (string) js.ExecuteScript(
                "var elementExists = document.getElementById('ssfErrorAlert'); var result = String(elementExists); if(result == null) console.log(elementExists.innerText); else console.log('Azaza is null!');");
        }
    }
}