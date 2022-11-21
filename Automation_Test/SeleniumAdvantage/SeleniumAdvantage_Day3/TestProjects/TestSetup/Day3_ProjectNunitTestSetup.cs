using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace SeleniumAdvantage_Day3.TestSetup
{
    public class Day3_ProjectNunitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://apichallenges.herokuapp.com";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
