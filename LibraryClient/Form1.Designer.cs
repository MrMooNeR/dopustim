namespace LibraryClient
{
    partial class Form1
    {
                          private System.ComponentModel.IContainer components = null;

                                protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

                                private void InitializeComponent()
        {
            Login = new Label();
            textBoxLogin = new TextBox();
            Pass = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            labelError = new Label();
            SuspendLayout();
                                          Login.AutoSize = true;
            Login.Location = new Point(31, 45);
            Login.Name = "Login";
            Login.Size = new Size(52, 20);
            Login.TabIndex = 0;
            Login.Text = "Логин";
            Login.Click += label1_Click;
                                          textBoxLogin.Location = new Point(118, 45);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(125, 27);
            textBoxLogin.TabIndex = 1;
                                          Pass.AutoSize = true;
            Pass.Location = new Point(31, 94);
            Pass.Name = "Pass";
            Pass.Size = new Size(62, 20);
            Pass.TabIndex = 2;
            Pass.Text = "Пароль";
                                          textBoxPassword.Location = new Point(118, 94);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(125, 27);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
                                          buttonLogin.Location = new Point(31, 182);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(94, 29);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
                                          labelError.AutoSize = true;
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(31, 240);
            labelError.Name = "labelError";
            labelError.Size = new Size(0, 20);
            labelError.TabIndex = 5;
                                          AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelError);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(Pass);
            Controls.Add(textBoxLogin);
            Controls.Add(Login);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Login;
        private TextBox textBoxLogin;
        private Label Pass;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Label labelError;
    }
}
