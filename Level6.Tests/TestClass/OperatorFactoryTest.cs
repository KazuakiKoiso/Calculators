using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Level6.Tests
{
    [TestClass]
    public class OperatorFactoryTest
    {
        [TestMethod, TestCategory("正常系")]
        public void 加算()
        {
            Operator ope = OperatorFactory.Create(OperateType.Plus);
            Assert.IsInstanceOfType(ope, typeof(Plus));
        }

        // [TestMethod, TestCategory("正常系")]
        // public void 減算()
        // [TestMethod, TestCategory("正常系")]
        // public void 乗算()
        // [TestMethod, TestCategory("正常系")]
        // public void 除算()

        [TestMethod, TestCategory("異常系")]
        public void 他()
        {
            Operator ope = OperatorFactory.Create(OperateType.None);
            Assert.IsNull(ope);
        }
    }
}
