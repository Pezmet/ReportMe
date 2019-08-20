using NUnit.Framework;
using ReportMe.Backend;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;



namespace ReportMe.Test
{
    [TestFixture]
    public class TestrailCalls
    {
        [Test]
        public void TestrailNotEmty()
        {
            string user = "svc_reportme.tg@ubisoft.com";
            string pass = "k2LsZ2yx9mM70rakhN5d-ZAypBRGpbQ1VAsh4w4Gq";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) != null);
           
        }
        [Test]
        public void TestRailResponseType()
        {
            string user = "svc_reportme.tg@ubisoft.com";
            string pass = "k2LsZ2yx9mM70rakhN5d-ZAypBRGpbQ1VAsh4w4Gq";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass).GetType() == typeof(JObject));
        }
        [Test]
        public void TestrailResponseUsername()
        {
            //incomplete username or typo
            string user = "svc_reportme.tg@u";
            string pass = "k2LsZ2yx9mM70rakhN5d-ZAypBRGpbQ1VAsh4w4Gq";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) == null);
            user = "!@#@$%$%$^&^*&(";
            sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) == null);
        }
        [Test]
        public void TestRailResponsePassword()
        {
            string user = "svc_reportme.tg@ubisoft.com";
            string pass = "Us3XyuWbEYN/Djv9";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) == null);
        }
    }
}
