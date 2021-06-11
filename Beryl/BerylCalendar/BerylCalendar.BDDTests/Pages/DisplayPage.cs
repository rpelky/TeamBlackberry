using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BerylCalendar.BDDTests.Pages
{
    public class DisplayPage
    {
        public IWebDriver WebDriver { get; }

        public DisplayPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement PrevMonthBtn => WebDriver.FindElement(By.Id("prevBtn"));
        public IWebElement NextMonthBtn => WebDriver.FindElement(By.Id("nextBtn"));
        public IWebElement MonthName => WebDriver.FindElement(By.Id("monthName"));

        public void clickPrev() => PrevMonthBtn.Click();
        public void clickNext() => NextMonthBtn.Click();

    }
}
