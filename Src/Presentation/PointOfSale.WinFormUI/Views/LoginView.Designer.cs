namespace PointOfSale.WinFormUI.Views
{
    partial class LoginView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.InputUsername = new PointOfSale.WinFormUI.ControlLibrary.Controls.Inputs.TextInputControl();
            this.InputPassword = new PointOfSale.WinFormUI.ControlLibrary.Controls.Inputs.TextInputControl();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(367, 112);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Padding = new System.Windows.Forms.Padding(10);
            this.lblLogin.Size = new System.Drawing.Size(76, 37);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "LOGIN";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(304, 272);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 25);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // InputUsername
            // 
            this.InputUsername.BackColor = System.Drawing.Color.Transparent;
            this.InputUsername.ErrorMessage = "";
            this.InputUsername.Label = "Username";
            this.InputUsername.Location = new System.Drawing.Point(304, 152);
            this.InputUsername.Name = "InputUsername";
            this.InputUsername.PasswordChar = '\0';
            this.InputUsername.Size = new System.Drawing.Size(200, 54);
            this.InputUsername.TabIndex = 6;
            this.InputUsername.TextboxText = "";
            this.InputUsername.UseSystemPasswordChar = false;
            // 
            // InputPassword
            // 
            this.InputPassword.BackColor = System.Drawing.Color.Transparent;
            this.InputPassword.ErrorMessage = "";
            this.InputPassword.Label = "Password";
            this.InputPassword.Location = new System.Drawing.Point(304, 212);
            this.InputPassword.Name = "InputPassword";
            this.InputPassword.PasswordChar = '●';
            this.InputPassword.Size = new System.Drawing.Size(200, 54);
            this.InputPassword.TabIndex = 7;
            this.InputPassword.TextboxText = "";
            this.InputPassword.UseSystemPasswordChar = true;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.InputPassword);
            this.Controls.Add(this.InputUsername);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLogin);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(820, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnLogin;
        private ControlLibrary.Controls.Inputs.TextInputControl InputUsername;
        private ControlLibrary.Controls.Inputs.TextInputControl InputPassword;
    }
}
