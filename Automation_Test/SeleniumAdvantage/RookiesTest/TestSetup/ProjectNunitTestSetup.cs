using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

namespace RookiesTest.TestSetup
{
    public class ProjectNunitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://demo.guru99.com.v4/";
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
