using Pages.CustomerAuthentication;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuriositySoftware.RunResult.Entities;
using CuriositySoftware.DataAllocation.Engine;

namespace Tests
{
    [TestFixture]
    [Ignore("Sample test requires correct ConnectionProfile setup")]
    public class CustomLoginTest : TestBase
    {
        [Test]
        [TestModellerId("6552c259-ba96-48b3-978f-a221b958946f")]
        public void InvalidLoginEmail()
        {
            CustomerLoginPage customerLoginPage = new CustomerLoginPage(driver);
            customerLoginPage.goToURL();
            customerLoginPage.enterEmail("james");
            customerLoginPage.enterPassword("james");
            customerLoginPage.submitLogin();
        }
    }
}
