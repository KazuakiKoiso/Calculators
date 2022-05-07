using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Level6.Tests
{
    /// <summary>テストクラスのサンプル</summary>
    [TestClass]
    public class SampleTest
    {
        // メソッド名は通常英語で記述するが、テストメソッドの時は
        // 内容を分かりやすくするために日本語で記述することも多い
        [TestMethod, TestCategory("正常系")]
        public void 引数が複数あり正常に平均値が算出できる()
        {
            double avg = Average(1, 2, 3);
            Assert.AreEqual(2, avg);
        }

        [TestMethod, TestCategory("正常系")]
        public void 引数が1つだけの場合そのまま平均値となる()
        {
            double avg = Average(10);
            Assert.AreEqual(10, avg);
        }

        [TestMethod, TestCategory("異常系")]
        public void 引数なしの場合例外が発生する()
        {
            Assert.ThrowsException<ArgumentException>(() => Average());
        }

        /// <summary>
        /// テストされるメソッド。本来は別プロジェクト内に存在する
        /// </summary>
        /// <param name="args">可変長引数</param>
        /// <returns>引数の平均値</returns>
        public double Average(params double[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("値は1つ以上指定してください。");
            }
            double sum = 0;
            foreach (double a in args)
            {
                sum += a;
            }
            return sum / args.Length;
        }
    }
}
