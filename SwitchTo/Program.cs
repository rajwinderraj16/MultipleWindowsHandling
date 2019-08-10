using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwitchTo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Initialize the Chrome Browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to the website
            driver.Navigate().GoToUrl("https://www.naukri.com/");

            //Maximize the web page
            driver.Manage().Window.Maximize();


            //Get the Parent window id
            String parentwindow = driver.CurrentWindowHandle;
            Console.WriteLine(parentwindow);

            //To get the name of the Parent window 
            String Title = driver.Title;
            Console.WriteLine("The  title of the parent window is" + Title);

            //To get the numbers of all child windows
            Console.WriteLine(driver.WindowHandles.Count);

            //To store all the window Ids in a List
            IList<string> MultiWindows = driver.WindowHandles.ToList();

            foreach (var Windowids in MultiWindows)
            {
                driver.SwitchTo().Window(Windowids);

                //To print the titles of all windows
                String AllTitles = driver.Title;
                Console.WriteLine(AllTitles);

                if (AllTitles == "KGISL")
                {
                    driver.SwitchTo().Window(Windowids);
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.XPath("//html//body//a//img")).Click();

                    //Switch to the new window
                    driver.SwitchTo().Window(Windowids);
                    driver.Navigate().GoToUrl("https://companies.naukri.com/kgisl-gss-jobs/jobs/?group=KGISLGSSNAUK");
                    driver.FindElement(By.XPath("//input[@id='nConfig_1_1']")).SendKeys("Testing");
                    driver.FindElement(By.XPath("//li[@class='social_bookmarks_facebook av-social-link-facebook social_icon_1']//a")).Click();

                    //Switch to the facebook window
                    driver.SwitchTo().Window(Windowids);
                    driver.Navigate().GoToUrl("https://www.facebook.com/kgislgss/");
                    driver.FindElement(By.XPath("//table//input[@id='email']")).SendKeys("Testing");
                    driver.SwitchTo().Window(parentwindow);
                }


                if (AllTitles == "Amazon")
                {
                    Thread.Sleep(2000);
                    driver.SwitchTo().Window(Windowids);
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.XPath("//html//body//a//img")).Click();

                    //Switch to the new window
                    driver.SwitchTo().Window(Windowids);
                    Thread.Sleep(3000);
                    driver.Navigate().GoToUrl("https://www.naukri.com/job-listings-Mega-Hiring-Event-at-Amazon-for-Cus--Amazon-Development-Centre-India-Pvt-Ltd--Noida-0-to-5-years-010819006391");
                    driver.FindElement(By.LinkText("I am Interested")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//input[@id='eml']")).SendKeys("rajjashan87@gmail.com");
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//button[@id='walkInSubmit']")).Click();

                    //Switch back to the parent window
                    Thread.Sleep(3000);
                    driver.SwitchTo().Window(parentwindow);

                    //Thread.Sleep(3000);
                    //driver.FindElement(By.XPath("//span[@id='allow']")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//span[@class='searchJob']")).Click();
                    driver.FindElement(By.XPath("//input[@placeholder='Skills, Designations, Companies']")).SendKeys("Testing");


                }
            }
        }
    }
}




































