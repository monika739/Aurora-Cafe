using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeAutomationSystem
{
    public partial class LoginForm : Form
    {
        public string UserRole { get; private set; }
        public string UserName { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            this.BackColor = Color.FromArgb(33, 41, 54);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Карточка
            panelCard.BackColor = Color.White;
            panelCard.Padding = new Padding(36, 28, 36, 28);

            lblTitle.ForeColor = Color.FromArgb(33, 41, 54);
            lblSubtitle.ForeColor = Color.FromArgb(120, 130, 145);

            // Поля
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Segoe UI", 10.5F);

            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 10.5F);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            // Кнопка
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(255, 138, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI Semibold", 10.5F);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Height = 42;
        }

        private void Submit()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            UserName = txtLogin.Text.Trim();
            UserRole = cmbRole.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)      => Submit();
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
