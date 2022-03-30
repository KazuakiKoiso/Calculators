using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Level5
{
    public partial class frmMain : Form
    {
        /// <summary>式の要素</summary>
        private List<Element> _elements = new List<Element>();
        /// <summary>現在の値</summary>
        private InputNumber _currentValue = new InputNumber();

        /// <summary>コンストラクタ</summary>
        public frmMain()
        {
            InitializeComponent();
            InitializeElements();
            EnableButtons();
        }

        /// <summary>内部リストの初期化</summary>
        private void InitializeElements()
        {
            _elements.Clear();
            _currentValue = new InputNumber();
            _elements.Add(_currentValue);
        }

        /// <summary>番号ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnNumber_Click(object sender, EventArgs e)
        {
            int num = int.Parse((sender as Button).Tag.ToString());
            _currentValue.Push(num);
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>ピリオドボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            _currentValue.AddPeriod();
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>演算子ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnOperator_Click(object sender, EventArgs e)
        {
            OperateType type = (OperateType)Enum.Parse(typeof(OperateType), (sender as Button).Tag.ToString());

            // 現在の値をリストに記憶し新しい入力を始める
            _elements.Add(OperatorFactory.Create(type));
            _currentValue = new InputNumber();
            _elements.Add(_currentValue);

            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>＝ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnEqual_Click(object sender, EventArgs e)
        {
            // 要素リストをツリーに変換
            TreeNode rootNode = TreeNode.Parse(_elements);
            double result = rootNode.Calculate();
            txtExpression.Text = $"{MakeExpression()} ＝ {new InputNumber(result)}";

            // ＝ボタンで結果を表示したら要素リストをクリアしておく
            // 見た目は計算結果が表示されているが、次にボタンが押されたときに最初から始まる
            InitializeElements();
            EnableButtons();
        }

        /// <summary>Cボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_currentValue.IsEmpty)
            {
                // 演算子が１つ以上ある場合は現在の値と演算子を２つとも除去する
                if (_elements.Any(elem => elem is Operator))
                {
                    _elements.RemoveAt(_elements.Count - 1);
                    _elements.RemoveAt(_elements.Count - 1);
                    _currentValue = _elements.Last() as InputNumber;
                }
            }
            else
            {
                // 入力中の値がある場合は値をクリアする
                _currentValue.Clear();
            }
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>ACボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnAllClear_Click(object sender, EventArgs e)
        {
            InitializeElements();
            txtExpression.Text = string.Empty;
            EnableButtons();
        }

        /// <summary>計算式を文字列化する</summary>
        /// <returns>計算式</returns>
        private string MakeExpression()
            => string.Join(" ", _elements);

        /// <summary>各ボタンのEnabledを制御する</summary>
        public void EnableButtons()
        {
            // 演算子ボタンは現在の値が空白の場合は押させない
            btnPlus.Enabled = !_currentValue.IsEmpty;
            btnMinus.Enabled = !_currentValue.IsEmpty;
            btnMulti.Enabled = !_currentValue.IsEmpty;
            btnDivision.Enabled = !_currentValue.IsEmpty;

            // ピリオドボタンも同じ
            btnPeriod.Enabled = !_currentValue.IsEmpty;
        }
    }
}
