using System;

namespace Level6
{
    /// <summary>数字の入力を管理するクラス</summary>
    public class InputNumber : Element
    {
        /// <returns>値</returns>
        private string _value = string.Empty;

        /// <summary>値の有無</summary>
        public bool IsEmpty => string.IsNullOrEmpty(_value);
        /// <summary>ピリオドの有無を確認</summary>
        public bool HasPeriod => _value.Contains(".");
        /// <summary>double型で値を取得する</summary>
        public double Value => IsEmpty ? 0 : double.Parse(_value.EndsWith(".") ? _value + "0" : _value);

        /// <summary>コンストラクタ</summary>
        public InputNumber()
        {
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="value">初期値</param>
        public InputNumber(double value)
        {
            _value = value.ToString();
        }

        /// <summary>数字を一桁追加</summary>
        /// <param name="number"></param>
        public void Push(int number)
        {
            if((number < 0) || (9 < number))
            {
                throw new ArgumentException("追加できる値は1桁のみです。");
            }
            _value += number.ToString();
        }

        /// <summary>ピリオドを追加</summary>
        public void AddPeriod()
        {
            if (HasPeriod)
            {
                throw new FormatException("小数点が重複しています。");
            }
            _value += string.IsNullOrEmpty(_value) ? "0." : ".";
        }

        /// <summary>一桁取り出す</summary>
        /// <returns>一桁。ピリオドの場合もあるのでchar型</returns>
        public char Pop()
        {
            char result = _value[_value.Length - 1];
            _value = _value.Substring(0, _value.Length - 1);
            return result;
        }

        /// <summary>クリア</summary>
        public void Clear()
            => _value = string.Empty;

        /// <summary>最後の入力がピリオドの場合に0を追加して値を確定させる</summary>
        public void Fix()
        {
            if(_value.EndsWith("."))
            {
                Push(0);
            }
        }

        /// <summary>文字列として値を取得</summary>
        /// <returns>入力中の値</returns>
        public override string ToString()
            => _value.Replace(".", "．").Replace("-", "－");
    }
}
