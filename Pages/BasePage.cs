using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class BasePage
    {
        protected IWebDriver m_Driver;

        protected WebDriverWait jsWait;

        protected IJavaScriptExecutor jsExec;

        public BasePage(IWebDriver driver)
        {
            this.m_Driver = driver;

            jsWait = new WebDriverWait(this.m_Driver, new TimeSpan(0, 0, 10));

            jsExec = (IJavaScriptExecutor)this.m_Driver;
        }

        protected IWebElement getWebElement(By by)
        {
            waitForLoaded(by, 100);
            waitForVisible(by, 100);

            try
            {
                return m_Driver.FindElement(by);
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected void waitForLoaded(By by, int waitTime)
        {
            WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

            for (int attempt = 0; attempt < waitTime; attempt++)
            {
                try
                {
                    m_Driver.FindElement(by);
                    break;
                }
                catch (Exception)
                {
                    m_Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 1);
                }
            }
        }

        protected void waitForVisible(By by, int waitTime)
        {
            IWebElement elem = m_Driver.FindElement(by);

            WebDriverWait wait = new WebDriverWait(m_Driver, new TimeSpan(0, 0, waitTime));

            wait.Until(m_Driver => elem.Displayed);
        }
    }
}
