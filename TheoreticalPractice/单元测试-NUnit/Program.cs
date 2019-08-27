using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace 单元测试_NUnit
{
    public class StringMerge
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string merge(string str1,string str2)
        {
            return str1 + str2;
        }
    }
    [TestClass()]
    public class StringMergeTests
    {
        [TestMethod()]
        public void mergeTest()
        {
            var str1 = "12345";
            var str2 = "67";
            var result = "12345678";
            Assert.AreEqual(new StringMerge().merge(str1, str2), result); 
        }
    }

}

