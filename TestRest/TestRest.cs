using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using RestServicePrøve.Controllers;

namespace TestRest
{
    [TestClass]
    public class TestRest
    {

        private CoinController con = new CoinController();


        [TestMethod]
        public void TestIFNotnull()
        {
            Assert.IsNotNull(con);
        }


        [TestMethod]
        public void testGetAll()
        {
            IEnumerable<Coins> getAllCoins = con.Get();

            int actualResult = getAllCoins.Count();

            Assert.AreEqual(5, actualResult);
        }


        [TestMethod]
        public void testGetOne()
        {
            Coins coin = con.Get(1);

            Assert.AreEqual(coin.Id, 1);
        }

        [TestMethod]
        public void testPost()
        {

            Coins record = new Coins(7, "GULD FB300", 9000, "Anders");
            con.Post(record);

            Coins postedCoin = con.Get(7);

            Assert.AreEqual(postedCoin.Navn, "Anders");
        }


        [TestMethod]
        public void testDelete()
        {
            con.Delete(7);


            Coins getRecord = con.Get(7);

            Assert.AreEqual(getRecord.Id, 7);

        }


        [TestMethod]
        public void testPut()
        {
            Coins oldRecord = con.Get(7);
            oldRecord.Navn = "Babdul";
            con.Put(7, oldRecord);
            Coins updatedRecord = con.Get(7);
            Assert.AreEqual("Babdul", updatedRecord.Navn);
        }


    }
}
