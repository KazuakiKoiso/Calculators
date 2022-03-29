using System;
using System.Windows.Forms;

namespace Level1
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
        private enum OperateType
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
        private double _value1;
        /// <summary>値２</summary>
        private double _value2;
        /// <summary>値１の有無</summary>
        private bool _hasValue1;
        /// <summary>値２の有無</summary>
        private bool _hasValue2;
        /// <summary>計算種別</summary>
        private OperateType _calcType;
        /// <summary>現在の入力モード</summary>
        private Mode _currentMode;

        /// <summary>コンストラクタ</summary>
        public frmMain()
        {
            InitializeComponent();
            EnableButtons();
        }

        /// <summary>現在入力中の値を取得</summary>
        /// <returns>現在入力中の値</returns>
        private double GetCurrentValue()
        {
            return _currentMode == Mode.Value1 ? _value1 : _value2;
        }

        /// <summary>現在入力中の値を設定</summary>
        /// <param name="value">設定値</param>
        private void SetCurrentValue(double value)
        {
            if (_currentMode == Mode.Value1)
            {
                _value1 = value;
                _hasValue1 = true;
            }
            else
            {
                _value2 = value;
                _hasValue2 = true;
            }
        }

        /// <summary>0ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn0_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>1ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn1_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 1);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>2ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn2_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 2);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>3ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn3_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 3);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>4ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn4_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 4);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>5ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn5_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 5);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>6ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn6_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 6);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>7ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn7_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 7);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>8ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn8_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 8);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>9ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btn9_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 9);
            txtExpression.Text = MakeExpression();
        }

        /// <summary>＋ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnPlus_Click(object sender, EventArgs e)
        {
            _calcType = OperateType.Plus;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>－ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnMinus_Click(object sender, EventArgs e)
        {
            _calcType = OperateType.Minus;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>×ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnMulti_Click(object sender, EventArgs e)
        {
            _calcType = OperateType.Multi;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        /// <summary>÷ボタンが押された時の処理</summary>
        /// <param name="sender">押されたボタン</param>
        /// <param name="e">イベント情報</param>
        private void btnDivision_Click(object sender, EventArgs e)
        {
            _calcType = OperateType.Division;
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
                case OperateType.Plus:
                    result = _value1 + _value2;
                    break;
                case OperateType.Minus:
                    result = _value1 - _value2;
                    break;
                case OperateType.Multi:
                    result = _value1 * _value2;
                    break;
                case OperateType.Division:
                    result = _value1 / _value2;
                    break;
            }
            txtExpression.Text = $"{MakeExpression()} ＝ {result}";
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
                    if (_hasValue2)
                    {
                        SetCurrentValue(0);
                        _hasValue2 = false;
                    }
                    else
                    {
                        _calcType = OperateType.None;
                        _currentMode = Mode.Value1;
                    }
                    break;
                case Mode.Value1:
                    SetCurrentValue(0);
                    _hasValue1 = false;
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
            _value1 = 0;
            _value2 = 0;
            _calcType = OperateType.None;
            _currentMode = Mode.Value1;
            txtExpression.Text = string.Empty;
            _hasValue1 = false;
            _hasValue2 = false;
            EnableButtons();
        }

        /// <summary>計算式を文字列化する</summary>
        /// <returns>計算式</returns>
        private string MakeExpression()
        {
            string expression = string.Empty;
            switch (_calcType)
            {
                case OperateType.None:
                    expression = _value1.ToString();
                    break;
                case OperateType.Plus:
                    expression = $"{_value1.ToString()} ＋ {_value2.ToString()}";
                    break;
                case OperateType.Minus:
                    expression = $"{_value1.ToString()} － {_value2.ToString()}";
                    break;
                case OperateType.Multi:
                    expression = $"{_value1.ToString()} × {_value2.ToString()}";
                    break;
                case OperateType.Division:
                    expression = $"{_value1.ToString()} ÷ {_value2.ToString()}";
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
