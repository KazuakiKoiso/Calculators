using System;
using System.IO;
using System.Text;

namespace Level6
{
    // ロガークラスのインターフェース
    public interface ILogger : IDisposable
    {
        /// <summary>ログにタイムスタンプを含む</summary>
        bool IncludeTimestamp { get; set; }
        /// <summary>ログ出力</summary>
        /// <param name="log">ログデータ</param>
        void Log(string log);
    }

    /// <summary>ファイルへのログ出力クラス</summary>
    public class FileLogger : ILogger
    {
        /// <summary>ログファイルパス</summary>
        protected string FilePath = string.Empty;
        /// <summary>ファイル出力制御クラス</summary>
        protected StreamWriter _writer = null;
        /// <summary>ログにタイムスタンプを含む</summary>
        public bool IncludeTimestamp { get; set; } = true;

        /// <summary>コンストラクタ</summary>
        /// <param name="filePath">ログファイルのフルパス</param>
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        // ログファイルを開く
        protected virtual void OpenFile()
        {
            string dir = Path.GetDirectoryName(FilePath);
            // ディレクトリがなければ作成する
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            // 追記モードで開く、ファイルが無ければ作成される
            _writer = new StreamWriter(FilePath, true, Encoding.UTF8);
        }

        /// <summary>ログを出力する</summary>
        /// <param name="log"></param>
        public virtual void Log(string log)
        {
            // 初回出力時にディレクトリ/ファイルを作成して掴む
            if (_writer == null)
            {
                OpenFile();
            }
            string now = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss] ");
            _writer.WriteLine(IncludeTimestamp ? now + log : log);
        }

        /// <summary>開放</summary>
        public virtual void Dispose()
        {
            _writer?.Dispose();
        }
    }
}
