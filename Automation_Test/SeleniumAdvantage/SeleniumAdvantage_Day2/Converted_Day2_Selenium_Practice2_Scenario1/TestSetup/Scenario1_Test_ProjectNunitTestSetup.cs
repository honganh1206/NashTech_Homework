using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace SeleniumAdvantage_Day2.TestSetup
{
    public class Scenario1_Test_ProjectNunitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "http://automationpractice.com/index.php";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
