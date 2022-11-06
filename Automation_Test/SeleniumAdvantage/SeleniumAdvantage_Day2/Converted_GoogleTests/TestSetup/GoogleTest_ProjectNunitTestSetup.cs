using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace SeleniumAdvantage_Day2.TestSetup
{
    public class GoogleTest_ProjectNunitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.google.com/";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
