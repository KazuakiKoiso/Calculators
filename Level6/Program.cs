using System;
using System.Windows.Forms;

namespace Level6
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // たとえ何もしなくてもここで例外をキャッチしないとusingのfinallyが実行されない
            try
            {
                using (FileLogger logger = new FileLogger(@"c:\logs\calc.log"))
                {
                    Application.Run(new frmMain(logger));
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
