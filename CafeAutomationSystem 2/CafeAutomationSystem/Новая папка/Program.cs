using System;
using System.Windows.Forms;

namespace CafeAutomationSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Готовим базу заранее, чтобы избежать сюрпризов
            try { DbHelper.EnsureCreated(); } catch { /* поймаем позже на UI */ }

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return;

                var mainForm = new Form1();
                mainForm.SetUserRole(login.UserRole);

                Application.Run(mainForm);
            }
        }
    }
}
