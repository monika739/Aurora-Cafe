namespace CafeAutomationSystem
{
    public partial class Form1
    {
        // Позволяет установить роль пользователя извне (вызывается из Program.cs)
        public void SetUserRole(string role)
        {
            if (string.IsNullOrEmpty(role))
                return;

            currentUserRole = role;
            ApplyRole();
        }
    }
}
