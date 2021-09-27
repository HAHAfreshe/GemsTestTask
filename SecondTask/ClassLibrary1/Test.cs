//Тестирование происходит в браузере Google chrome


using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;

namespace TestingWebSite
{
    [TestFixture]
    public class Test
    {
        //рабочий каталог, относительно исполняемого файла (в нашем случае относительно DLL)
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); 
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //создание и доавбление настроек для открытия google chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        //Проверка существования разделов на странице https://gemsdev.ru/geometa/
        //такие разделы как: GeoMeta, Государственная система обеспечения градостроительной деятельности,
        //Городская аналитика, Другие наши продукты
        [Test]
        public void Testing_the_presence_of_the_necessry_sections()
        {
            driver.Navigate().GoToUrl("https://gemsdev.ru/geometa/");
            Assert.IsTrue(driver.PageSource.Contains("GeoMeta"));
            Assert.IsTrue(driver.PageSource.Contains("Государственная система обеспечения градостроительной деятельности"));
            Assert.IsTrue(driver.PageSource.Contains("Городская аналитика"));
            Assert.IsTrue(driver.PageSource.Contains("Другие наши продукты"));


        }

        //Проверка существования кнопки с сылкой https://xn--c1aaceme9acfqh.xn--p1ai/
        [Test]
        public void Link_testing()
        {
            driver.Navigate().GoToUrl("https://gemsdev.ru/geometa/");
            string exp = driver.FindElement(By.XPath("//a[contains(@class, 'btn btn-orange mt-4')]")).GetAttribute("href");
            string act = "https://xn--c1aaceme9acfqh.xn--p1ai/";
            Assert.AreEqual(exp, act);
        }
    }
}
