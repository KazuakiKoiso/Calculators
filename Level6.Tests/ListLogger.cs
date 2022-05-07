using System;
using System.Collections.Generic;

namespace Level6.Tests
{
    /// <summary>
    /// メモリ内部にログを蓄積するクラス。
    /// Moqを使用しない場合、こういったダミークラスを作成する
    /// </summary>
    public class ListLogger : ILogger
    {
        /// <summary>ログにタイムスタンプを含む</summary>
        public bool IncludeTimestamp { get; set; } = false;
        /// <summary>ログデータ</summary>
        public List<string> LogData { get; set; }

        /// <summary>コンストラクタ</summary>
        public ListLogger()
        {
            LogData = new List<string>();
        }

        /// <summary>ログ出力</summary>
        /// <param name="log">ログデータ</param>
        public void Log(string log)
        {
            string now = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss] ");
            LogData.Add(IncludeTimestamp ? now + log : log);
        }

        /// <summary>開放</summary>
        public void Dispose()
        {
        }
    }
}
