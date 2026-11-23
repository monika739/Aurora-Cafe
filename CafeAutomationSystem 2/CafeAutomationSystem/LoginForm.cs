using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CafeAutomationSystem
{
    public partial class LoginForm : Form
    {
        public string UserRole { get; private set; } = "Staff";
        public string UserName { get; private set; } = "";

        public LoginForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            cmbUser.Items.Clear();
            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                using (var cmd = new SQLiteCommand(
                    "SELECT Name FROM Users ORDER BY Name", conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        cmbUser.Items.Add(r["Name"].ToString());
                }
            }
            catch { /* база ещё не готова */ }

            if (cmbUser.Items.Count > 0)
                cmbUser.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cmbUser.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя", "Вход",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = cmbUser.SelectedItem.ToString();
            try
            {
                using (var conn = DbHelper.GetOpenConnection())
                using (var cmd = new SQLiteCommand(
                    "SELECT Role FROM Users WHERE Name = @n LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    var v = cmd.ExecuteScalar();
                    UserRole = (v == null || v == DBNull.Value) ? "Staff" : v.ToString();
                    UserName = name;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка входа: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
