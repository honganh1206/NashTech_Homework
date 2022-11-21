using CoreFramework.API_Core;
using Microsoft.AspNetCore.Mvc;
using RookiesTest.PageObj;
using RookiesTest.Services;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    [TestFixture] 
    public class APITest : NUnitAPITestSetup
    {

        //[Test]
        //public void APIRequestTest()
        //{
        //    API_Response response = new APIToDoService().LoginRequest("standard_user", "secret_sauce");
        //    Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        //}
        [TestCase("/236", "OK")]
        public void APITest_Request04(string todoId, string statusCode)
        {
            APIToDoService service = new APIToDoService();
            API_Response response = service.GetTodoRequest(todoId);
            Assert.That(response.responseStatusCode, Is.EqualTo(statusCode));
        }
    }
}