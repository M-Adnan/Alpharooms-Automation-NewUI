using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using AlphaRooms.AutomationFramework.Selenium;

namespace AlphaRooms.AutomationFramework
{
    public class HotelResultsPageRnd
    {
        public static int PickRandomResultPage()
        {
            return FlightResultsPageRnd.PickRandomResultPage();
        }

        public static int PickRandomHotel()
        {
            int totalHotelResults = GetNumberOfResults();
            int randHotel = PickRandomHotelNo(totalHotelResults);
            return randHotel;
        }

        private static int GetNumberOfResults()
        {
            IWebElement EstablishmentResults = Driver.Instance.FindElement(By.Id("establishmentResults"));
            ReadOnlyCollection<IWebElement> divallSearchResults = EstablishmentResults.FindElements(By.CssSelector("ul.list.results li.list-item.card"));
            return divallSearchResults.Count;
        }

        private static int PickRandomHotelNo(int totalResults)
        {
            if (totalResults > 0)
            {
                int HotelNo = HomePageRnd.Random.Next(1, totalResults);
                return HotelNo;
            }
            else
                throw new Exception("No search results available");
        }
    }
}
