using CuriositySoftware.DataAllocation.Engine;
using CuriositySoftware.DataAllocation.Entities;
using CuriositySoftware.RunResult.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModellerCSharp.Pages.Samples.Splendid;

namespace Tests
{
    [TestFixture]
    [Ignore("Sample test requires correct ConnectionProfile setup")]
    public class SplendidCreateOppertunity_DataAllocation : TestBase
    {
        [Test]
        [DataAllocation("Splendid Dev Team", "CreateLeads", (new[] { "Campaign Active and Mail", "Find Valid Account" }))]
        public void DefaultProfileGoToUrlPositiveNamePositiveAccountNameNegativeAmountSave1()
        {
            DataAllocationResult accountNameAllocResult = dataAllocationEngine.GetDataResult("Splendid Dev Team", "CreateLeads", "Find Valid Account");
            DataAllocationResult campaignNameAllocResult = dataAllocationEngine.GetDataResult("Splendid Dev Team", "CreateLeads", "Campaign Active and Mail");

            LoginPage _LoginPage = new LoginPage(driver);
            _LoginPage.GoToUrl();

            _LoginPage.Enter_UsernameInput("admin");

            _LoginPage.Enter_PasswordInput("admin");

            _LoginPage.Click_LoginButton();

            OpportunitiesPage _PagesOpportunities = new OpportunitiesPage(driver);
            _PagesOpportunities.GoToUrl();

            _PagesOpportunities.Enter_Name("omnis");

            _PagesOpportunities.Enter_AccountName(accountNameAllocResult.GetValueByColumn("NAME").ToString());

            _PagesOpportunities.Enter_CampaignName(campaignNameAllocResult.GetValueByColumn("NAME").ToString());

            _PagesOpportunities.Enter_Amount("100.2.22");

            _PagesOpportunities.Click__Save_();
        }
    }
}
