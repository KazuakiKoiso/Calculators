using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace Level6.Tests
{
    /// <summary>
    /// Moqを使ったfrmMainのテスト
    /// </summary>
    [TestClass]
    public class frmMainMoqTest
    {
        // 数値ボタン
        private Button[] _numberButton = new Button[10];

        // テストを実行する前に１度だけ実行される。
        // テスト対象メソッドがいくつあってもここは１回だけなので
        // コンストラクタ的に使える
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
        }

        // テスト終了時に実行される。
        // テスト対象メソッドがいくつあってもここは１回だけなので
        // デストラクタ的に使える
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // 各テストメソッドを実行する前に実行される
        // テストメソッドを２つ選択して実行した場合、それぞれの前に２回実行される
        [TestInitialize]
        public void TestInitialize()
        {
            // 数値ボタンはprivateなフィールドのため、モックには含まれない
            // （含まれるかもしれないが取り出せない）
            // そのためイベントハンドラに渡すsenderとしてのButtonを外部で用意する必要がある
            for (int i = 0; i < 10; i++)
            {
                _numberButton[i] = new Button()
                {
                    Tag = i.ToString(),
                };
            }
        }

        // 各テストメソッド終了後に実行される
        // テストメソッドを２つ選択して実行した場合、それぞれの後に２回実行される
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void 初期化()
        {
            // ロガークラスのモックを作成することでログファイルを作成させない
            Mock<ILogger> loggerMock = new Mock<ILogger> { CallBase = false };

            // 初期化時の処理をテストするので特に何もしない
            using (frmMain frmMain = new frmMain(loggerMock.Object))
            {
            }

            loggerMock.Verify(m => m.Log("------------電卓が起動しました。------------"));
        }

        [TestMethod]
        public void 初期化時にEnableButtonsが実行される()
        {
            // EnableButtonsのテストなのでロガーは不要
            Mock<frmMain> mainMock = new Mock<frmMain>(null) { CallBase = true };

            // Objectにアクセスしないとコンストラクタが実行されないらしい
            var a = mainMock.Object;

            // EnableButtons()が1回だけ実行される
            mainMock.Protected().Verify("EnableButtons", Times.Once());
        }

        [TestMethod]
        public void 終了()
        {
            // ロガークラスのモックを作成することでログファイルを作成させない
            Mock<ILogger> loggerMock = new Mock<ILogger> { CallBase = false };
            Mock<frmMain> mainMock = new Mock<frmMain>(loggerMock.Object) { CallBase = true };

            // 初期化時の処理をテストするので特に何もしない
            mainMock.Object.Show();
            mainMock.Object.Close();

            loggerMock.Verify(m => m.Log("------------電卓を終了します。------------"));
        }

        [TestMethod]
        public void 数値ボタン()
        {
            // ロガークラスのモックを作成することでログファイルを作成させない
            Mock<ILogger> loggerMock = new Mock<ILogger> { CallBase = false };
            Mock<frmMain> mainMock = new Mock<frmMain>(loggerMock.Object) { CallBase = true };

            // _elementsのgetterでローカルのリストをアクセスするようしておくことで
            // あとで検証ができる
            List<Element> elements = new List<Element>();
            mainMock.Protected().SetupGet<List<Element>>("_elements").Returns(elements);

            // このタイミングでEnableButtonsを検証しておくことで初期化時点での
            // EnableButtons実行を確認する
            mainMock.Object.Show();
            mainMock.Protected().Verify("EnableButtons", Times.Once());

            // 1ボタンが押されたことにする
            PrivateObject po = new PrivateObject(mainMock.Object);
            po.Invoke("btnNumber_Click", _numberButton[1], EventArgs.Empty);

            // 検証
            mainMock.Protected().Verify("EnableButtons", Times.Exactly(2));
            Assert.AreEqual(1, elements.Count);

            InputNumber currentValue = elements[0] as InputNumber;
            Assert.AreEqual(1, currentValue.Value);

            mainMock.Object.Close();
        }
    }
}
