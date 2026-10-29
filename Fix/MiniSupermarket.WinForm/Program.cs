using MiniSupermarket.WinForms;

namespace MiniSupermarket.WinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Vòng lặp: Đăng nhập -> Shell. Bấm Đăng xuất thì quay lại Đăng nhập.
            do
            {
                SessionManager.LogoutRequested = false;
                using (var login = new FormLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }
                Application.Run(new FormMainShell());
            } while (SessionManager.LogoutRequested);
        }
    }
}
