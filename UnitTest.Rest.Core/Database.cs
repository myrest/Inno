using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;

namespace UnitTest.RestCore
{
    [TestClass]
    public class Database
    {
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                var dataSet = ConfigurationManager.GetSection("system.data") as System.Data.DataSet;
                dataSet.Tables[0].Rows.Add("SQLite Data Provider"
                , ".Net Framework Data Provider for SQLite"
                , "System.Data.SQLite"
                , "System.Data.SQLite.SQLiteFactory, System.Data.SQLite");
            }
            catch (System.Data.ConstraintException) { }
        }

        [TestMethod]
        public void TestMethod1()
        {
            /*
            BestGAP_Manager bm = new BestGAP_Manager();
            BestGAP_Info bi = new BestGAP_Info()
            {
                BestIdeaGroupSNs = "1,2,3,4",
                Description = "123",
                Document = "123sdf",
                LastUpdate = 444444,
                MyGAP = "asdf",
                TopicSN = 99,
                UserSN = 88
            };
            long newid = bm.Insert(bi);
            Assert.IsTrue(newid > 0);

            var obj = bm.GetByID(newid);
            Assert.IsNotNull(obj);

            obj.TopicSN = 100;
            bm.Update(obj.SN, obj, new List<string>() { "TopicSN" });
            var newobj = bm.GetByID(newid);
            Assert.IsTrue(newobj.TopicSN == 100);

            long rtn = bm.Delete(newid);
            Assert.IsTrue(rtn > 0);

            obj = bm.GetByID(newid);
            Assert.IsNull(obj);
            */
        }
    }
}