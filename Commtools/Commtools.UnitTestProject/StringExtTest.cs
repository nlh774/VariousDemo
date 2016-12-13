using Commtools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Commtools.UnitTestProject
{
    /// <summary>
    ///这是 StringExtTest 的测试类，旨在
    ///包含所有 StringExtTest 单元测试
    ///</summary>
    [TestClass()]
    public class StringExtTest
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


        /// <summary>
        ///ContainsKeys 的测试
        ///</summary>
        [TestMethod()]
        public void ContainsKeysTest()
        {
            string str = "123456789NNN";
            string[] keys = new string[] { "1","N"};
            bool expected = true;
            bool actual;
            actual = StringExt.ContainsKeys(str, keys);
            Assert.AreEqual(expected, actual);

            str = "23456789NNN";
            keys = new string[] { "1", "N", "Y" };
            expected = false;
            actual = StringExt.ContainsKeys(str, keys);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///CountSubString 的测试
        ///</summary>
        [TestMethod()]
        public void CountSubStringTest()
        {
            string str = "nlh774nlh774";
            string substring = "7";
            int expected = 4;
            int actual;
            actual = StringExt.CountSubString(str, substring);
            Assert.AreEqual(expected, actual);

            str = "nlh774nlh774";
            substring = "nlh";
            expected = 2;
            actual = StringExt.CountSubString(str, substring);
            Assert.AreEqual(expected, actual);

            str = "nlh774nlh774";
            substring = "n";
            expected = 2;
            actual = StringExt.CountSubString(str, substring);
            Assert.AreEqual(expected, actual);

            str = "nlh774nlh774";
            substring = "nlh775";
            expected = 0;
            actual = StringExt.CountSubString(str, substring);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetValueBetweenMarks 的测试
        ///</summary>
        [TestMethod()]
        public void GetValueBetweenMarksTest()
        {
            string str = "<script>12345</script>";
            string beginMark = "<script>";
            string endMark = "</script>";
            string expected = "12345";
            string actual;
            actual = StringExt.GetValueBetweenMarks(str, beginMark, endMark);
            Assert.AreEqual(expected, actual);

            str = "<script></script>";
            beginMark = "<script>";
            endMark = "</script>";
            expected = "";
            actual = StringExt.GetValueBetweenMarks(str, beginMark, endMark);
            Assert.AreEqual(expected, actual);

            str = "<script1></script1>";
            beginMark = "<script>";
            endMark = "</script>";
            expected = "";
            actual = StringExt.GetValueBetweenMarks(str, beginMark, endMark);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///IsNotNullOrWhiteSpace 的测试
        ///</summary>
        [TestMethod()]
        public void IsNotNullOrWhiteSpaceTest()
        {
            string str = "xxx";
            bool expected = true;
            bool actual;
            actual = StringExt.IsNotNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);

            str = null;
            expected = false;
            actual = StringExt.IsNotNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);

            str = "    ";
            expected = false;
            actual = StringExt.IsNotNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///IsNullOrWhiteSpace 的测试
        ///</summary>
        [TestMethod()]
        public void IsNullOrWhiteSpaceTest()
        {
            string str = "";
            bool expected = true;
            bool actual;
            actual = StringExt.IsNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);

            str = "           ";
            expected = true;
            actual = StringExt.IsNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);

            str = null;
            expected = true;
            actual = StringExt.IsNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);

            str = "xxx";
            expected = false;
            actual = StringExt.IsNullOrWhiteSpace(str);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///RemoveSubString 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveSubStringTest()
        {
            string str = "xxxyy";
            string substring = "yy";
            string expected = "xxx";
            string actual;
            actual = StringExt.RemoveSubString(str, substring);
            Assert.AreEqual(expected, actual);

            str = "xxxyy";
            substring = "x";
            expected = "yy";
            actual = StringExt.RemoveSubString(str, substring);
            Assert.AreEqual(expected, actual);

            str = "xxxyy";
            substring = "zz";
            expected = "xxxyy";
            actual = StringExt.RemoveSubString(str, substring);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ToInt64 的测试
        ///</summary>
        [TestMethod()]
        public void ToInt64Test()
        {
            string str = "11111111111";
            long defaultValue = -1;
            long expected = 11111111111;
            long actual;
            actual = StringExt.ToInt64(str, defaultValue);
            Assert.AreEqual(expected, actual);

            str = "11111111111.1";
            defaultValue = -1;
            expected = -1;
            actual = StringExt.ToInt64(str, defaultValue);
            Assert.AreEqual(expected, actual);

            str = "xx";
            defaultValue = 0;
            expected = 0;
            actual = StringExt.ToInt64(str, defaultValue);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ToInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ToInt32Test()
        {
            string str = "1111";
            int defaultValue = -1;
            int expected = 1111;
            int actual;
            actual = StringExt.ToInt32(str, defaultValue);
            Assert.AreEqual(expected, actual);

            str = "1111.1";
            defaultValue = -1;
            expected = -1;
            actual = StringExt.ToInt32(str, defaultValue);
            Assert.AreEqual(expected, actual);

            str = "xx";
            defaultValue = 0;
            expected = 0;
            actual = StringExt.ToInt32(str, defaultValue);
            Assert.AreEqual(expected, actual);
        }
    }
}
