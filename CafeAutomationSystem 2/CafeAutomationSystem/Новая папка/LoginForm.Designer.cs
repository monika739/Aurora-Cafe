namespace CafeAutomationSystem
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelCard   = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.label1      = new System.Windows.Forms.Label();
            this.txtLogin    = new System.Windows.Forms.TextBox();
            this.label2      = new System.Windows.Forms.Label();
            this.cmbRole     = new System.Windows.Forms.ComboBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();

            //
            // panelCard
            //
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Controls.Add(this.cmbRole);
            this.panelCard.Controls.Add(this.label2);
            this.panelCard.Controls.Add(this.txtLogin);
            this.panelCard.Controls.Add(this.label1);
            this.panelCard.Controls.Add(this.lblSubtitle);
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Location = new System.Drawing.Point(140, 65);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(380, 320);

            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTitle.Location = new System.Drawing.Point(36, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "☕  Café Manager";

            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.Location = new System.Drawing.Point(38, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Войдите, чтобы продолжить";

            //
            // label1 — Логин
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 110);
            this.label1.Name = "label1";
            this.label1.Text = "Логин";

            //
            // txtLogin
            //
            this.txtLogin.Location = new System.Drawing.Point(38, 132);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(305, 28);

            //
            // label2 — Роль
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 175);
            this.label2.Name = "label2";
            this.label2.Text = "Роль";

            //
            // cmbRole
            //
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
                "Admin",
                "Staff",
                "Intern"});
            this.cmbRole.Location = new System.Drawing.Point(38, 197);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(305, 28);
            this.cmbRole.SelectedIndexChanged +=
                new System.EventHandler(this.cmbRole_SelectedIndexChanged);

            //
            // btnLogin
            //
            this.btnLogin.Location = new System.Drawing.Point(38, 250);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(305, 42);
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);

            //
            // LoginForm
            //
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(33, 41, 54);
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.Controls.Add(this.panelCard);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Café Manager — Вход";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel    panelCard;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblSubtitle;
        private System.Windows.Forms.Label    label1;
        private System.Windows.Forms.TextBox  txtLogin;
        private System.Windows.Forms.Label    label2;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button   btnLogin;
    }
}
