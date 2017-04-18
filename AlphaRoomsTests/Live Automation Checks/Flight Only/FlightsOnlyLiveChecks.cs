using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlphaRooms.AutomationFramework;

namespace AlphaRooms.AutomationFramework.Tests.Live_Automation_Checks.Flight_Only
{
    public class FlightsOnlyLiveChecks : AlpharoomsTestBase
    {
        [Test]
        [Category("Live")]
        public void FlightsOnlyLiveChecks_Tenerife()
        {
            //Enter Hotel only search data
            HomePage.SearchFor().FlightOnly().ToDestination("Tenerife").FromDepartureAirport("London Heathrow, London, United Kingdom (LHR)")
                .FromCheckIn(Calendar.PickRandomCheckInDate()).ToCheckOut(Calendar.PickRandomCheckOutDate()).SearchAndCapture();

            //Check if result page is displayed within 60 sec
            Assert.That(FlightResultsPage.IsDisplayed(), "Flight Search Result Page isn't displayed within 60 sec");

            //Check if any hote results are displayed for the search
            Assert.That(FlightResultsPage.AreResultsDisplayed(), "No Results are available for the flight search");

            //Select first room option of the first hotel displayed on the very first result page
            FlightResultsPage.SelectFlight().ByFlightNumber(FlightResultsPageRnd.PickRandomFlight()).Continue();

            //Check if the extra page is displayed
            Assert.That(ExtrasPage.IsDisplayed(), "Extras page is not displayed within 60 sec");

            //Click Booknow button
            ExtrasPage.BookFlight().ContinueAndCapture();

            //Check Payment Page is displayed
            Assert.That(PaymentPage.IsDisplayed(), "Payment page is not displayed");
        }

        [Test]
        [Category("Live")]
        public void ShouldBook_2nd_MostPopularFlight_Alicante()
        {
            //Enter Hotel only search data
            HomePage.SearchFor().FlightOnly().ToDestination("Alicante").FromCheckIn(Calendar.PickRandomCheckInDate())
                .ToCheckOut(Calendar.PickRandomCheckOutDate()).FromDepartureAirport("London Heathrow, London, United Kingdom (LHR)").SearchAndCapture();

            //Check if result page is displayed within 60 sec
            Assert.That(FlightResultsPage.IsDisplayed(), "Flight Search Result Page isn't displayed within 60 sec");

            //Check if any hote results are displayed for the search
            Assert.That(FlightResultsPage.AreResultsDisplayed(), "No Results are available for the flight search");

            //Select first room option of the first hotel displayed on the very first result page
            FlightResultsPage.SelectFlight().ByFlightNumber(FlightResultsPageRnd.PickRandomFlight()).Continue();

            //Check if the extra page is displayed
            Assert.That(ExtrasPage.IsDisplayed(), "Extras page is not displayed within 60 sec");

            //Click Booknow button
            ExtrasPage.BookFlight().ContinueAndCapture();

            //Check Payment Page is displayed
            Assert.That(PaymentPage.IsDisplayed(), "Payment page is not displayed");

        }
    }
}
