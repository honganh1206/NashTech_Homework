using RookiesTest.Common;
using RookiesTest.DAO;
using RookiesTest.PageObj;
using RookiesTest.TestSetup;

namespace RookiesTest.TestCases
{
    [TestFixture]
    public class CreateCustomerTest : NUnitWebTestSetup
    {
        public void VerifyCreatedCustomer(CustomerInfo customer)
        {
            CustomerSuccessPage createSuccessPage = new CustomerSuccessPage(_driver);
            Assert.That(createSuccessPage.GetName(), Is.EqualTo(customer.Name));
        }
        [Test]
        public void ID_CreateCustomer()
        {
             
            CommonFlow.LoginFLow(_driver);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsWelcomeMessageDisplayed(), "Login failed");
            MenuLeft menuLeft = new MenuLeft(_driver);
            menuLeft.GoToCreateCustomerPage();

            CustomerInfo validCustomer = new CustomerInfo("Haha", "Hanoi", "11111999");

            NewCustomerPage newCustomerPage = new NewCustomerPage(_driver);
            newCustomerPage.InputCustomerInfo(validCustomer);
        }
    }
}
