using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criar a referencia para o navegador
            IWebDriver driver = new ChromeDriver();

            //Navegar na pagina do google
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Procurar o elemento
            driver.FindElement(By.Name("q")).SendKeys("DEVOPS");

            // Click on the Search button
            driver.FindElement(By.Name("btnK")).Click();

            // Use a Css Selector to go down to the actual element, in this case <a>
            var results = driver.FindElements(By.CssSelector("#rso > div > div > div.r > a"));
            foreach (var item in results)
            {
                //Extract the page title and the url from the result
                var title = item.FindElement(By.TagName("h3")).Text;
                var url = item.GetProperty("href");
                Console.WriteLine($"{title} | {url}");
            }

        }
    }
}
