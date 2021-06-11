using System;
using BerylCalendar.BDDTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BerylCalendar.BDDTests.Steps
{
    [Binding]
    public class MonthNavigation
    {
        DisplayPage displayPage = null;

        //[Given(@"the user is logged in to any account")]
        //public void GivenTheUserIsLoggedInToAnyAccount()
        //{            
        //    ScenarioContext.Current.Pending();
        //}
        
        [Given(@"the user is on the display page")]
        public void GivenTheUserIsOnTheDisplayPage()
        {IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://localhost:5001/Event/Display/2021/6/11");
            displayPage = new DisplayPage(webDriver);
        }

        [Given(@"the user has already navigated to a different month using the arrows")]
        public void GivenTheUserHasAlreadyNavigatedToADifferentMonthUsingTheArrows()
        {
            displayPage.clickPrev();
            displayPage.clickPrev();
            displayPage.clickNext();
        }

        [When(@"they click on the back arrow by the month name")]
        public void WhenTheyClickOnTheBackArrowByTheMonthName()
        {
            displayPage.clickPrev();
        }
        
        [When(@"they click on the forward arrow by the month name")]
        public void WhenTheyClickOnTheForwardArrowByTheMonthName()
        {
            displayPage.clickNext();
        }

        [When(@"they click on any arrow by the month name")]
        public void WhenTheyClickOnAnyArrowByTheMonthName()
        {
            displayPage.clickPrev();
        }

        [Then(@"the display will change to show the month prior to the current month\.")]
        public void ThenTheDisplayWillChangeToShowTheMonthPriorToTheCurrentMonth_()
        {
            Assert.That(displayPage.MonthName.Equals("May 2021"), Is.True);
        }
        
        [Then(@"the display will change to show the month after to the current month\.")]
        public void ThenTheDisplayWillChangeToShowTheMonthAfterToTheCurrentMonth_()
        {
            Assert.That(displayPage.MonthName.Equals("July 2021"), Is.True);
        }

        [Then(@"the display will change to show the desired month\.")]
        public void ThenTheDisplayWillChangeToShowTheDesiredMonth_()
        {
            Assert.That(displayPage.MonthName.Equals("April 2021"), Is.True);
        }
    }
}
