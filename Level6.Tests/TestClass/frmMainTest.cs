using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Level6.Tests
{
    /// <summary>
    /// frmMainをMoqを使わずにテストする場合のテストクラス
    /// frmMainのプロパティやメソッドがほとんどprivateかprotectedなので
    /// 起動時と終了時のログくらいしかテストできることがない
    /// </summary>
    [TestClass]
    public class frmMainTest
    {
        [TestMethod, TestCategory("正常系")]
        public void 起動ログ()
        {
            using (var logger = new ListLogger())
            using (frmMain frmMain = new frmMain(logger))
            {
                string expected = "------------電卓が起動しました。------------";
                Assert.AreEqual(expected, logger.LogData[0]);
            }
        }

        [TestMethod, TestCategory("正常系")]
        public void 終了ログ()
        {
            using (var logger = new ListLogger())
            {
                using (frmMain frmMain = new frmMain(logger))
                {
                    // FormClosingイベントを正常に発生させるために一度表示する必要がある
                    // Show()でモードレス表示後にCloseするので一瞬だけ画面が見える
                    frmMain.Show();
                    frmMain.Close();
                }
                string expected = "------------電卓を終了します。------------";
                Assert.AreEqual(2, logger.LogData.Count);
                Assert.AreEqual(expected, logger.LogData[1]);
            }
        }
    }
}
