using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            
            string browser = args[0];
            string search = args[1];

            Console.WriteLine("You have select Browser: " + browser +" and you want to search "+ search+ " Value");

            if (browser.Equals("chrome"))
            {
                IWebDriver driver = new ChromeDriver("D:\\Projects\\lib");

                //Browser Open
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine("Browser Opened in Maximized view");

                //Url Open
                var URL = driver.Url = "https://the-internet.herokuapp.com";
                Console.WriteLine("Open URl: " + URL);

                string searchValue = null;
                foreach (Object obj in args)
                {
                    searchValue = obj.ToString();
                }

                Console.WriteLine("Enter Search Value: " + searchValue);
                Thread.Sleep(200);
               
                try
                {
                    var LinkName = driver.FindElement(By.LinkText(searchValue));
                    LinkName.Click();
                    Console.WriteLine("You Choose " + searchValue);
                    Thread.Sleep(5000);
                    var text = driver.FindElement(By.XPath("//*[@id='content']/div/h3")).Text;

                    if (text.Equals(searchValue))
                    {
                        Console.WriteLine("Link : " + searchValue + " Open Successfully");
                    }

                }

                catch (NoSuchElementException e)
                {
                    Console.WriteLine("Link's Name Not Found "+ searchValue +" :"+ e.Message);
                }

                // Browser Close
                driver.Close();
                Console.WriteLine("browser "+ browser + " Closed Successfully");

            }


            else if(browser.Equals("FireFox"))
            {
                IWebDriver driver = new FirefoxDriver("D:\\Projects\\lib");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine("Browser Opened in Maximized view");

                //URL Open
                var URL = driver.Url = "https://the-internet.herokuapp.com";
                Console.WriteLine("Open URl: " + URL);

                string searchValue = null;
                foreach (Object obj in args)
                {
                    searchValue = obj.ToString();
                }

                Console.WriteLine("Enter Search Value: " + searchValue);
                Thread.Sleep(200);

                try
                {
                    var LinkName = driver.FindElement(By.LinkText(searchValue));
                    LinkName.Click();
                    Console.WriteLine("You Choose " + searchValue);
                    Thread.Sleep(5000);
                    var text = driver.FindElement(By.XPath("//*[@id='content']/div/h3")).Text;

                    if (text.Equals(searchValue))
                    {
                        Console.WriteLine("Link : " + searchValue + " Open Successfully");
                    }

                }

                catch (NoSuchElementException e)
                {
                    Console.WriteLine("Link's Name Not Found " + searchValue + " :" + e.Message);
                }

                // Browser Close
                driver.Close();
                Console.WriteLine("browser " + browser + " Closed Successfully");
               
            }
            else
            {
                Console.WriteLine("Please Choose Valid Browser Name : chrome or FireFox and Run again");
            }

            Console.WriteLine("Press Any Key to Close");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
