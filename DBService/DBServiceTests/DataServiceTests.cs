using NUnit.Framework;
using DBService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Tests
{
    [TestFixture]
    public class DataServiceTests
    {
        [Test]
        public void GetUserLinksTest()
        {
            var guid = "99319358-EFEE-4C85-909D-5697D23B0086";
            var dataService = new DataService();

            var assert = dataService.GetUserLinks(guid);

            Assert.That(assert, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void GetUserLinksTest1()
        {
            var guid = "notFoundGuid";
            var dataService = new DataService();

            var assert = dataService.GetUserLinks(guid);

            Assert.That(assert, Is.Not.Null.Or.Not.Empty);
            Assert.That(assert, Does.Contain("ERROR"));
        }

        [Test]
        public void GetUserLinksTest2()
        {
            var guid = "99319358-EFEE-4C85-909D-5697D23B0087";
            var dataService = new DataService();

            var assert = dataService.GetUserLinks(guid);

            Assert.That(assert, Is.Null);
        }

        [Test]
        public void GetUserLinksTest3()
        {
            string guid = null;
            var dataService = new DataService();

            var assert = dataService.GetUserLinks(guid);

            Assert.That(assert, Is.Null);
        }

        [Test()]
        public void InsertLinkOrCreateUserTest()
        {
            var dataService = new DataService();

            var assert = dataService.InsertLinkOrCreateUser("http://google.com", 3);

            Assert.That(assert, Is.Not.Null.Or.Not.Empty);
        }

        [Test()]
        public void InsertLinkOrCreateUserTest1()
        {
            var dataService = new DataService();

            var assert = dataService.InsertLinkOrCreateUser("http://google.com", null);

            Assert.That(assert, Is.Not.Null.Or.Not.Empty);
        }

        [Test()]
        public void IncrementLinkTest()
        {
            var dataService = new DataService();

            var assert = dataService.IncrementLink("Q");

            Assert.That(assert, Is.Not.Null.Or.Not.Empty);
            Assert.That(assert, Does.Contain("google"));
        }
    }
}