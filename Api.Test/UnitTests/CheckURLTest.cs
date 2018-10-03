using System;
using System.IO;
using System.Net;
using System.Reflection;
using Api.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.Test.UnitTests
{
    [TestClass]
    public class CheckURLTest
    {
        [TestMethod]
        public void UrlCheckTest()
        {
            bool result = true;
            var urlHelper = new UrlHelper();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"urls.json");
            var targets = urlHelper.ObtenerTarget(path);

            urlHelper.TestUrlTargets(targets);
                

            Assert.IsTrue(result);

        }

        
    }
}
