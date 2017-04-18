using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AlphaRooms.AutomationFramework.Selenium;
using System.Collections.ObjectModel;
using System.Threading;

namespace AlphaRooms.AutomationFramework.Panels
{
    public class TopPanel
    {
        public void ClickAlphaRoomsLogo()
        {
            Logger.AddClickAction("Alpharoom Logo");
            Driver.Instance.SwitchTo().DefaultContent();
            IWebElement AlpharoomsLogoImage = Driver.Instance.FindElement(By.CssSelector("div.row-fluid a.pull-left div.logo"));
            AlpharoomsLogoImage.Click();
        }

        public void ClickMenu(MenuItem item)
        {
            throw new NotImplementedException();
        }

        public void ClickLocation(Location location)
        {
            Thread.Sleep(1000);
            
            IWebElement locationImg = Driver.Instance.FindElement(By.CssSelector("a#channelMenuLink.site-header-channel-toggle.toggle"));
            locationImg.Click();

            IWebElement locationBtn = Driver.Instance.FindElement(By.CssSelector("div.menu.nav-main-secondary.nav-main-secondary-channel.to-toggle.anim-fade-reveal"));
            ReadOnlyCollection<IWebElement> locationOptions = locationBtn.FindElements(By.CssSelector("ul.list.menu-list li.list-item.menu-item"));

            switch (location)
            {
                case Location.Ireland:
                    foreach(IWebElement siteLocation in locationOptions)
                        if (siteLocation.Text == "Ireland")
                        {
                            siteLocation.FindElement(By.TagName("a")).Click();
                            HomePage.Data.SiteLocation = Location.Ireland;
                            break;
                        }
                    break;

                case Location.UnitedKingdom:
                    foreach (IWebElement siteLocation in locationOptions)
                        if (siteLocation.Text == "United Kingdom")
                        {
                            siteLocation.FindElement(By.TagName("a")).Click();
                            HomePage.Data.SiteLocation = Location.UnitedKingdom;
                            break;
                        }
                    break;

                case Location.UnitedStates:
                    foreach (IWebElement siteLocation in locationOptions)
                        if (siteLocation.Text == "United States")
                        {
                            siteLocation.FindElement(By.TagName("a")).Click();
                            HomePage.Data.SiteLocation = Location.UnitedStates;
                            break;
                        }
                    break;
            }
        }
    }
}
