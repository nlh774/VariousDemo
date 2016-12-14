using Commtools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Commtools.UnitTestProject
{
    
    
    /// <summary>
    ///这是 WebHelperTest 的测试类，旨在
    ///包含所有 WebHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class WebHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        #region 泛型类测试搞不定
        /////<summary>
        /////GetResponse 泛型的测试
        /////</summary>
        //[TestMethod()]
        //public void GetResponseTTest()
        //{
        //    //get 无参
        //    WebHelper target = new WebHelper("http://localhost:1444/Interface/CityServiceGet", HttpMethod.Get);
        //    var expected = new List<City> 
        //    {
        //        new City{Id=1,Name="上海"},
        //        new City{Id=2,Name="北京"},
        //        new City{Id=3,Name="苏州"},
        //        new City{Id=4,Name="重庆"},
        //        new City{Id=5,Name="南京"},
        //        new City{Id=6,Name="嘉兴"},
        //    };
        //    List<City> actual;
        //    actual = target.GetResponse<List<City>>();
        //    Assert.AreEqual<List<City>>(expected, actual);//.AreEqual(expected, actual);
        //    //get 有参
        //    target.RequestParam = "id=4";
        //    expected = new List<City> 
        //    {
        //        new City{Id=4,Name="嘉兴"},
        //    };
        //    actual = target.GetResponse<List<City>>();
        //    Assert.AreEqual(expected, actual);

        //    //post 必须有参
        //    target.Method = HttpMethod.Post;
        //    target.RequestParam = "name=上海";
        //    expected = new List<City> 
        //    {
        //        new City{Id=1,Name="上海"},
        //    };
        //    actual = target.GetResponse<List<City>>();
        //    Assert.AreEqual(expected, actual);
        //} 
        #endregion

        /// <summary>
        ///GetResponse 的测试
        ///</summary>
        [TestMethod()]
        public void GetResponseTest()
        {
            //get 无参
            WebHelper target = new WebHelper("http://localhost:1444/Interface/CityServiceGet",HttpMethod.Get);
            string expected = "[{\"Id\":1,\"Name\":\"上海\"},{\"Id\":2,\"Name\":\"北京\"},{\"Id\":3,\"Name\":\"苏州\"},{\"Id\":4,\"Name\":\"重庆\"},{\"Id\":5,\"Name\":\"南京\"},{\"Id\":6,\"Name\":\"嘉兴\"}]";
            string actual;
            actual = target.GetResponse();
            Assert.AreEqual(expected, actual);
            //get 有参
            target.RequestParam = "id=1";
            expected = "[{\"Id\":1,\"Name\":\"上海\"}]";
            actual = target.GetResponse();
            Assert.AreEqual(expected, actual);

            //post 必须有参
            target.RequestUrl = "http://localhost:1444/Interface/CityServicePost";
            target.Method = HttpMethod.Post;
            target.RequestParam = "name=上海";
            expected = "[{\"Id\":1,\"Name\":\"上海\"}]";
            actual = target.GetResponse();
            Assert.AreEqual(expected, actual);
        }

    }

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
