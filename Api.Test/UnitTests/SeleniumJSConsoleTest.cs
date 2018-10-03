using System;
using Api.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.Test.UnitTests
{
    [TestClass]
    public class SeleniumJSConsoleTest
    {
        [TestMethod]
        public void CaptureBrowserLogsTest()
        {
            var seleniumJSConsole = new SeleniumJSConsole();
            seleniumJSConsole.CaptureBrowserLogs();

        }
    }
}
