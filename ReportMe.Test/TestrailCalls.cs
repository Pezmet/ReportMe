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
            string user = "";
            string pass = "";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) != null);
           
        }
        [Test]
        public void TestRailResponseType()
        {
            string user = "";
            string pass = "";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass).GetType() == typeof(JObject));
        }
        [Test]
        public void TestrailResponseUsername()
        {
            //incomplete username or typo
            string user = "";
            string pass = "";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) == null);
            user = "!@#@$%$%$^&^*&(";
            sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) == null);
        }
        [Test]
        public void TestRailResponsePassword()
        {
            string user = "";
            string pass = "";
            var sut = new Get();
            Assert.That(sut.Trequest("get_project/", "44", user, pass) == null);
        }
    }
}
