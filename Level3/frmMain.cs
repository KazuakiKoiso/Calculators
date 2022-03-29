using System;
using System.Windows.Forms;

namespace Level3
{
    public partial class frmMain : Form
    {
        /// <summary>現在の入力モード</summary>
        private enum Mode
        {
            /// <summary>値１を入力中</summary>
            Value1,
            /// <summary>値２を入力中</summary>
            Value2,
            /// <summary>計算完了</summary>
            Calculated,
        }
        /// <summary>計算種別</summary>
        private enum CalcType
        {
            /// <summary>未入力</summary>
            None,
            /// <summary>加算</summary>
            Plus,
            /// <summary>減算</summary>
            Minus,
            /// <summary>乗算</summary>
            Multi,
            /// <summary>除算</summary>
            Division,
        }
        /// <summary>値１</summary>
        private InputNumber _value1 = new InputNumber();
        /// <summary>値２</summary>
        private InputNumber _value2 = new InputNumber();
        /// <summary>計算種別</summary>
        private CalcType _calcType;
        /// <summary>現在の入力モード</summary>
        private Mode _currentMode;

        /// <summary>コンストラクタ</summary>
        public frmMain()
        {
            InitializeComponent();
            EnableButtons();
        }

        /// <summary>番号ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnNumber_Click(object sender, EventArgs e)
        {
            int num = int.Parse((sender as Button).Tag.ToString());
            (_currentMode == Mode.Value1 ? _value1 : _value2).Push(num);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>ピリオドボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            (_currentMode == Mode.Value1 ? _value1 : _value2).AddPeriod();
            txtExpression.Text = MakeExpression();
        }

        /// <summary>演算子ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnOperator_Click(object sender, EventArgs e)
        {
            CalcType type = (CalcType)Enum.Parse(typeof(CalcType), (sender as Button).Tag.ToString());
            _calcType = type;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>＝ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double result = 0;
            switch (_calcType)
            {
                // 加算
                case CalcType.Plus:
                    result = _value1.Value + _value2.Value;
                    break;
                // 減算
                case CalcType.Minus:
                    result = _value1.Value - _value2.Value;
                    break;
                // 乗算
                case CalcType.Multi:
                    result = _value1.Value * _value2.Value;
                    break;
                // 除算
                case CalcType.Division:
                    result = _value1.Value / _value2.Value;
                    break;
            }
            txtExpression.Text = $"{MakeExpression()} ＝ {result.ToString().Replace(".","．")}";
            _currentMode = Mode.Calculated;
            EnableButtons();
        }

        /// <summary>Cボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            switch (_currentMode)
            {
                case Mode.Value2:
                    if (_value2.IsEmpty)
                    {
                        // 値２が未入力の場合は演算子の入力をクリアする
                        _calcType = CalcType.None;
                        _currentMode = Mode.Value1;
                    }
                    else
                    {
                        // 値２を入力中は値２を１文字クリアする
                        _value2.Pop();
                    }
                    break;
                case Mode.Value1:
                    // 値１を１文字クリアする
                    _value1.Pop();
                    break;
            }
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>ACボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnAllClear_Click(object sender, EventArgs e)
        {
            _value1.Clear();
            _value2.Clear();
            _calcType = CalcType.None;
            _currentMode = Mode.Value1;
            txtExpression.Text = string.Empty;
            EnableButtons();
        }

        /// <summary>計算式を文字列化する</summary>
        /// <returns>計算式</returns>
        private string MakeExpression()
        {
            string expression = string.Empty;
            switch (_calcType)
            {
                case CalcType.None:
                    expression = _value1.ToString();
                    break;
                case CalcType.Plus:
                    expression = $"{_value1} ＋ {_value2}";
                    break;
                case CalcType.Minus:
                    expression = $"{_value1} － {_value2}";
                    break;
                case CalcType.Multi:
                    expression = $"{_value1} × {_value2}";
                    break;
                case CalcType.Division:
                    expression = $"{_value1} ÷ {_value2}";
                    break;
            }
            return expression;
        }

        /// <summary>各ボタンのEnabledを制御する</summary>
        private void EnableButtons()
        {
            btn1.Enabled = (_currentMode != Mode.Calculated);
            btn2.Enabled = (_currentMode != Mode.Calculated);
            btn3.Enabled = (_currentMode != Mode.Calculated);
            btn4.Enabled = (_currentMode != Mode.Calculated);
            btn5.Enabled = (_currentMode != Mode.Calculated);
            btn6.Enabled = (_currentMode != Mode.Calculated);
            btn7.Enabled = (_currentMode != Mode.Calculated);
            btn8.Enabled = (_currentMode != Mode.Calculated);
            btn9.Enabled = (_currentMode != Mode.Calculated);
            btn0.Enabled = (_currentMode != Mode.Calculated);

            btnPlus.Enabled = (_currentMode != Mode.Calculated);
            btnMinus.Enabled = (_currentMode != Mode.Calculated);
            btnMulti.Enabled = (_currentMode != Mode.Calculated);
            btnDivision.Enabled = (_currentMode != Mode.Calculated);
            btnEqual.Enabled = (_currentMode == Mode.Value2);

            btnClear.Enabled = (_currentMode != Mode.Calculated);
        }
    }
}
