using System.Drawing;
using System.Windows.Forms;

namespace CafeAutomationSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel    panelTop;
        private Label    lblBrand;
        private Label    lblSub;
        private Label    lblUserCaption;
        private ComboBox cmbUser;
        private Button   btnLogin;
        private Label    lblVersion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            Color accent  = Color.FromArgb(255, 138, 0);
            Color dark    = Color.FromArgb(33, 41, 54);
            Color content = Color.FromArgb(245, 247, 251);
            Color gray    = Color.FromArgb(120, 130, 145);

            // ---- Форма ----
            this.Text            = "Aurora Cafe — Вход";
            this.ClientSize      = new Size(420, 340);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.BackColor       = content;
            this.Font            = new Font("Segoe UI", 10F);

            // ---- Шапка ----
            panelTop = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 110,
                BackColor = dark
            };

            lblBrand = new Label
            {
                Text      = "☕  AURORA CAFE",
                AutoSize  = true,
                Font      = new Font("Segoe UI Semibold", 20F),
                ForeColor = accent,
                Location  = new Point(24, 20)
            };

            lblSub = new Label
            {
                Text      = "Система автоматизации кафе",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(160, 170, 185),
                Location  = new Point(27, 68)
            };

            panelTop.Controls.Add(lblBrand);
            panelTop.Controls.Add(lblSub);

            // ---- Выбор пользователя ----
            lblUserCaption = new Label
            {
                Text      = "Кто вы?",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = gray,
                Location  = new Point(36, 128)
            };

            cmbUser = new ComboBox
            {
                Location      = new Point(36, 148),
                Size          = new Size(348, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font          = new Font("Segoe UI", 11F),
                FlatStyle     = FlatStyle.Flat,
                BackColor     = Color.White
            };

            // ---- Кнопка входа ----
            btnLogin = new Button
            {
                Text      = "Войти",
                Location  = new Point(36, 204),
                Size      = new Size(348, 46),
                BackColor = accent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI Semibold", 12F),
                Cursor    = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += btnLogin_Click;

            // ---- Версия ----
            lblVersion = new Label
            {
                Text      = "v1.0  |  2026",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(180, 185, 195),
                Location  = new Point(36, 300)
            };

            this.Controls.Add(panelTop);
            this.Controls.Add(lblUserCaption);
            this.Controls.Add(cmbUser);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lblVersion);
        }
    }
}
