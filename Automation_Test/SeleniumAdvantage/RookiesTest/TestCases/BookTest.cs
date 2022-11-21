using CoreFramework.API_Core;
using Microsoft.AspNetCore.Mvc;
using RookiesTest.PageObj;
using RookiesTest.Services;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    [TestFixture] 
    public class BookTest : NUnitAPITestSetup
    {

        //[Test]
        //public void APIRequestTest()
        //{
        //    API_Response response = new APIToDoService().LoginRequest("standard_user", "secret_sauce");
        //    Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        //}
        [Test]
        public void ListBooksTest()
        {

        }
        public void EditBooksTest()
        {

        }
    }
}