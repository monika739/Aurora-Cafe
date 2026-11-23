namespace CafeAutomationSystem
{
    public partial class Form1
    {
        /// <summary>
        /// Устанавливает роль и отображаемое имя пользователя.
        /// Вызывается из Program.cs после успешного входа.
        /// </summary>
        public void SetUserRole(string role, string userName = "")
        {
            if (string.IsNullOrEmpty(role))
                return;

            currentUserRole = role;

            // Показываем имя в шапке
            if (!string.IsNullOrEmpty(userName))
                lblHeaderUser.Text = "👤  " + userName;

            ApplyRole();
        }
    }
}
