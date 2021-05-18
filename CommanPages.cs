using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pallavi_AutomationFreamwork
{
    public class CommanPages
    {
        Baseclass MyBase = new Baseclass();
        AutomationFramwork Automation = new AutomationFramwork();

        public void MyLoginApplication(string userName, string password)
        {
            IWebElement LoginCustAcc = DriverContext.driver.FindElement(By.XPath("//*[@title='Log in to your customer account']"));
            LoginCustAcc.Click();

            IWebElement Username = DriverContext.driver.FindElement(By.XPath("//*[contains(text(),'Already registered?')]/..//..//*[@id='email']"));
            IWebElement Password = DriverContext.driver.FindElement(By.Id("passwd"));
            IWebElement Submit = DriverContext.driver.FindElement(By.Id("SubmitLogin"));

            Username.SendKeys(userName);
            Password.SendKeys(password);
            Submit.Click();

        }

        public void Add_Shirt()
        {
            //I have Search Item one for T-Shirt
            IWebElement SearchBox = DriverContext.driver.FindElement(By.XPath("//div[@id='search_block_top']//form//input[@id='search_query_top']"));
            IWebElement SubmitSearch = DriverContext.driver.FindElement(By.Name("submit_search"));

            SearchBox.SendKeys("T-shirts");
            SubmitSearch.Click();

            IWebElement T_shirt = DriverContext.driver.FindElement(By.XPath("(//*[@class='block_content products-block']//a)[1]"));
            T_shirt.Click();

            //Select the item Size
            SelectElement selList = new SelectElement(DriverContext.driver.FindElement(By.Id("group_1")));
            selList.SelectByValue("2");

            IWebElement AddToCartBtn = DriverContext.driver.FindElement(By.Id("add_to_cart"));
            AddToCartBtn.Click();

            IWebElement ContShopBtn = DriverContext.driver.FindElement(By.XPath("//*[@title='Continue shopping']"));
            ContShopBtn.Click();
        }

        //Add Secound  Item in Cart
        public void AddSecondItem()
        {
            IWebElement SearchBox = DriverContext.driver.FindElement(By.XPath("//div[@id='search_block_top']//form//input[@id='search_query_top']"));
            SearchBox.SendKeys("Blouse");
            IWebElement SubmitSearch = DriverContext.driver.FindElement(By.Name("submit_search"));
            SubmitSearch.Click();

            IWebElement Blouse_ = DriverContext.driver.FindElement(By.XPath("//*[@class='product_img_link'][@title='Blouse']"));
            Blouse_.Click();

            IWebElement AddToCartBtn = DriverContext.driver.FindElement(By.Id("add_to_cart"));
            AddToCartBtn.Click();

            IWebElement ProceedCheckOut = DriverContext.driver.FindElement(By.XPath("//*[@title='Proceed to checkout']"));
            ProceedCheckOut.Click();
        }

        public void IVerify_CartItems()
        {
            //I have verified cart Items
            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_description']//a[contains(text(),'Blouse')]/..//following-sibling::*/a[contains(text(),'S')]")).Displayed.Equals(true);
            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_description']//a[contains(text(),'Blouse')]/../..//following-sibling::td[@data-title='Total']//span[contains(text(),'$27.00')]")).Displayed.Equals(true);


            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_description']//a[contains(text(),'Printed Chiffon Dress')]/..//following-sibling::*/a[contains(text(),'M')]")).Displayed.Equals(true);
            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_description']//a[contains(text(),'Printed Chiffon Dress')]/../..//following-sibling::td[@data-title='Total']//span[contains(text(),'$16.40')]")).Displayed.Equals(true);


        }

        public void IConfirmOrder()
        {
            //Summary has been Proceed 
            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_total_price']//span[contains(text(),'$45.40')]")).Displayed.Equals(true);
            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_navigation clearfix']//span[contains(text(),'Proceed to checkout')]")).Click();

            //Verify Address Proceed
            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_navigation clearfix']//span[contains(text(),'Proceed to checkout')]")).Click();

            DriverContext.driver.FindElement(By.XPath("//*[@class='checkbox']//div//span")).Click();

            DriverContext.driver.FindElement(By.XPath("//*[@class='cart_navigation clearfix']//span[contains(text(),'Proceed to checkout')]")).Click();
            DriverContext.driver.FindElement(By.ClassName("bankwire")).Click();
            DriverContext.driver.FindElement(By.XPath("//*[contains(text(),'I confirm my order')]")).Click();

        }
        //Method for :Logout
        public void Logout()
        {
            IWebElement Logout = DriverContext.driver.FindElement(By.ClassName("logout"));
            Logout.Click();
        }

        //Method for Navigate to oder add msg
        public void NavigateToOrdersAddMessage()
        {
            DriverContext.driver.FindElement(By.XPath("//*[@class='account']//span")).Click();
            DriverContext.driver.FindElement(By.XPath("//*[@title='Orders']//span")).Click();
            DriverContext.driver.FindElement(By.XPath("(//*[@class='history_detail footable-last-column']//span)[1]")).Click();
            DriverContext.driver.FindElement(By.XPath(" //*[@id='sendOrderMessage']/p[3]/textarea")).SendKeys("Awaiting order delivery soon");
        }

        //Verify Success / Alert msgs
        public void verifySuccessAlertAndMessage()
        {
            DriverContext.driver.FindElement(By.XPath("//*[@id='sendOrderMessage']/div/button/span")).Click();
            DriverContext.driver.FindElement(By.XPath("//*[@class='alert alert-success'][contains(text(),'Message successfully sent')]"));
            DriverContext.driver.FindElement(By.XPath("//*[@class='account']//span")).Click();
            DriverContext.driver.FindElement(By.XPath("//*[@title='Orders']//span")).Click();
            DriverContext.driver.FindElement(By.XPath("(//*[@class='history_detail footable-last-column']//span)[1]")).Click();
            DriverContext.driver.FindElement(By.XPath("(//h3[contains(text(),'Messages')]/..//*[contains(text(),'Awaiting order delivery soon')])[1]")).Displayed.Equals(true);
        }

        //I verify Orders details
        public void GoToOrders()
        {
            DriverContext.driver.FindElement(By.XPath("//*[@class='account']//span")).Click();
            DriverContext.driver.FindElement(By.XPath("//*[@title='Orders']//span")).Click();
            DriverContext.driver.FindElement(By.XPath("(//*[@class='history_detail footable-last-column']//span)[1]")).Click();
        }
    }
}
