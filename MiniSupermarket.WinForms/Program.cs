using System;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Thiết lập kiểu hiển thị giao diện WinForms chuẩn
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi chạy FormLogin đầu tiên
            Application.Run(new FormLogin());
        }
    }
}