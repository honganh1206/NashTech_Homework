using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.API_Core;
using NUnit.Framework;
using SeleniumAdvantage_Day3.Services;
using SeleniumAdvantage_Day3.TestSetup;

namespace SeleniumAdvantage_Day3.TestCases
{
    public class Day3_API_Test : Day3_ProjectNunitTestSetup
    {
        [Test]
        public void APIRequestTest04()
        {
            API_Response response = new APIChallengesService().Request04();
            Assert.That(response.responseStatusCode, Is.EqualTo("NotFound"));
        }
        [Test]
        public void APIRequestTest05()
        {
            API_Response response = new APIChallengesService().Request05();
            Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        }

        [Test]
        public void APIRequestTest08()
        {
            API_Response response = new APIChallengesService().Request08();
            Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        }
        [Test]
        public void APIRequestTest09()
        {
            API_Response response = new APIChallengesService().Request09();
            Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        }

    }
}
