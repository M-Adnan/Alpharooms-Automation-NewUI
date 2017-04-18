using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlphaRooms.AutomationFramework;

namespace AlphaRooms.AutomationFramework.Tests.Live_Automation_Checks.Hotel_Only
{
    public class HotelOnlyLiveChecks : AlpharoomsTestBase
    {
        [Test]
        [Category("Live")]
        public void HotelOnlyDestinationSearch_Benidorm()
        {
            //Select the uk location
            HomePage.TopPanel.ClickLocation(Location.UnitedKingdom);

            //Enter Hotel only search data
            HomePage.SearchFor().HotelOnly().ToDestination("Mallorca (Majorca)").FromCheckIn(Calendar.PickRandomCheckInDate())
                .ToCheckOut(Calendar.PickRandomCheckOutDate()).SearchAndCapture();

            //Check if result page is displayed within 60 sec
            Assert.That(HotelResultsPage.IsDisplayed(), "Hotel Search Result Page isn't displayed within 60 sec");

            //Check if any hote results are displayed for the search
            Assert.That(HotelResultsPage.AreResultsDisplayed(), "No Results are available for the hotel search");

            //Select first room option of the first hotel displayed on the very first result page
            HotelResultsPage.SelectRoom().ByHotelNumber(HotelResultsPageRnd.PickRandomHotel()).OnlyOneRoomWithAvailableRoom(1).ContinueAndCapture();

            //Check if the extra page is displayed
            Assert.That(ExtrasPage.IsDisplayed(), "Extras page is not displayed");

            //Click Booknow button
            ExtrasPage.BookHotel().ContinueAndCapture();

            //Check Payment Page is displayed
            Assert.That(PaymentPage.IsDisplayed(), "Payment page is not displayed");

        }
    
        [Test]
        [Category("Live")]
        public void HotelOnlyDestinationSearch_Tenerife()
        {
            //Enter Hotel only search data
            HomePage.SearchFor().HotelOnly().ToDestination("Tenerife").FromCheckIn(Calendar.PickRandomCheckInDate())
                .ToCheckOut(Calendar.PickRandomCheckOutDate()).SearchAndCapture();

            //Check if result page is displayed within 60 sec
            Assert.That(HotelResultsPage.IsDisplayed(), "Hotel Search Result Page isn't displayed within 60 sec");

            //Check if any hote results are displayed for the search
            Assert.That(HotelResultsPage.AreResultsDisplayed(), "No Results are available for the hotel search");

            //Select first room option of the first hotel displayed on the very first result page
            HotelResultsPage.SelectRoom().ByHotelNumber(HotelResultsPageRnd.PickRandomHotel()).OnlyOneRoomWithAvailableRoom(1).ContinueAndCapture();

            //Check if the extra page is displayed
            Assert.That(ExtrasPage.IsDisplayed(), "Extras page is not displayed");

            //Click Booknow button
            ExtrasPage.BookHotel().ContinueAndCapture();

            //Check Payment Page is displayed
            Assert.That(PaymentPage.IsDisplayed(), "Payment page is not displayed");

        }

    }
}
