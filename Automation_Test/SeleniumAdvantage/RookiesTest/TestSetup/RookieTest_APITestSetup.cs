﻿using CoreFramework.NUnitTestSetup;

namespace RookiesTest.TestSetup
{
    public class RookieTest_APITestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.saucedemo.com/";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }

}
