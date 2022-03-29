namespace Level3
{
    /// <summary>数字の入力を管理するクラス</summary>
    public class InputNumber
    {
        /// <returns>値</returns>
        private string _value = string.Empty;

        /// <summary>値の有無</summary>
        public bool IsEmpty => string.IsNullOrEmpty(_value);
        /// <summary>double型で値を取得する</summary>
        public double Value => double.Parse(_value[_value.Length - 1] == '.' ? _value + "0" : _value);

        /// <summary>コンストラクタ</summary>
        public InputNumber()
        {
        }

        /// <summary>数字を一桁追加</summary>
        /// <param name="number"></param>
        public void Push(int number)
            => _value += number.ToString();

        /// <summary>ピリオドを追加</summary>
        public void AddPeriod()
            => _value += ".";

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

        /// <summary>文字列として値を取得</summary>
        /// <returns>入力中の値</returns>
        public override string ToString()
            => _value.Replace(".","．");
    }
}
