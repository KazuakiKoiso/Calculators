using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Level6.Tests
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod, TestCategory("正常系")]
        public void 加算()
        {
            Plus plus = new Plus();

            Assert.AreEqual(OperateType.Plus, plus.OperateType);
            Assert.AreEqual(3, plus.Calculate(1, 2));
        }

        [TestMethod, TestCategory("正常系")]
        public void 減算()
        {
            Minus minus = new Minus();

            Assert.AreEqual(OperateType.Minus, minus.OperateType);
            Assert.AreEqual(-1, minus.Calculate(1, 2));
        }

        // [TestMethod, TestCategory("正常系")]
        // public void 乗算()
        // [TestMethod, TestCategory("正常系")]
        // public void 除算()

        // [TestMethod, TestCategory("異常系")]
        // public void ゼロ除算()
    }
}
