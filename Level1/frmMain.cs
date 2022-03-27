using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Level1
{
    public partial class frmMain : Form
    {
        private enum Mode
        {
            Value1,
            Value2,
            Calculated,
        }
        private enum CalcType
        {
            None,
            Plus,
            Minus,
            Multi,
            Division,
        }
        private double _value1;
        private double _value2;
        private bool _hasValue1;
        private bool _hasValue2;
        private CalcType _calcType;
        private Mode _currentMode;

        public frmMain()
        {
            InitializeComponent();
            EnableButtons();
        }

        private double GetCurrentValue()
        {
            return _currentMode == Mode.Value1 ? _value1 : _value2;
        }

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

        private void btn0_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10);
            txtExpression.Text = MakeExpression();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 1);
            txtExpression.Text = MakeExpression();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 2);
            txtExpression.Text = MakeExpression();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 3);
            txtExpression.Text = MakeExpression();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 4);
            txtExpression.Text = MakeExpression();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 5);
            txtExpression.Text = MakeExpression();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 6);
            txtExpression.Text = MakeExpression();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 7);
            txtExpression.Text = MakeExpression();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 8);
            txtExpression.Text = MakeExpression();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SetCurrentValue(GetCurrentValue() * 10 + 9);
            txtExpression.Text = MakeExpression();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _calcType = CalcType.Plus;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            _calcType = CalcType.Minus;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            _calcType = CalcType.Multi;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            _calcType = CalcType.Division;
            _currentMode = Mode.Value2;
            txtExpression.Text = MakeExpression();
            EnableButtons();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            double result = 0;
            switch (_calcType)
            {
                case CalcType.Plus:
                    result = _value1 + _value2;
                    break;
                case CalcType.Minus:
                    result = _value1 - _value2;
                    break;
                case CalcType.Multi:
                    result = _value1 * _value2;
                    break;
                case CalcType.Division:
                    result = _value1 / _value2;
                    break;
            }
            txtExpression.Text = $"{MakeExpression()} ＝ {result}";
            _currentMode = Mode.Calculated;
            EnableButtons();
        }

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
                        _calcType = CalcType.None;
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

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            _value1 = 0;
            _value2 = 0;
            _calcType = CalcType.None;
            _currentMode = Mode.Value1;
            txtExpression.Text = string.Empty;
            _hasValue1 = false;
            _hasValue2 = false;
            EnableButtons();
        }

        private string MakeExpression()
        {
            string expression = string.Empty;
            switch (_calcType)
            {
                case CalcType.None:
                    expression = _value1.ToString();
                    break;
                case CalcType.Plus:
                    expression = $"{_value1.ToString()} ＋ {_value2.ToString()}";
                    break;
                case CalcType.Minus:
                    expression = $"{_value1.ToString()} － {_value2.ToString()}";
                    break;
                case CalcType.Multi:
                    expression = $"{_value1.ToString()} × {_value2.ToString()}";
                    break;
                case CalcType.Division:
                    expression = $"{_value1.ToString()} ÷ {_value2.ToString()}";
                    break;
            }
            return expression;
        }

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
