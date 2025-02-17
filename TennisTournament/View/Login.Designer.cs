namespace TennisTournament
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usernameTxtBox = new System.Windows.Forms.TextBox();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.userTypeComboBox = new System.Windows.Forms.ComboBox();
            this.comboBoxLng = new System.Windows.Forms.ComboBox();
            this.changeLngBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTxtBox
            // 
            resources.ApplyResources(this.usernameTxtBox, "usernameTxtBox");
            this.usernameTxtBox.Name = "usernameTxtBox";
            this.usernameTxtBox.TextChanged += new System.EventHandler(this.usernameTxtBox_TextChanged);
            // 
            // passwordTxtBox
            // 
            resources.ApplyResources(this.passwordTxtBox, "passwordTxtBox");
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.TextChanged += new System.EventHandler(this.passwordTxtBox_TextChanged);
            // 
            // loginBtn
            // 
            resources.ApplyResources(this.loginBtn, "loginBtn");
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registerBtn
            // 
            resources.ApplyResources(this.registerBtn, "registerBtn");
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // userTypeComboBox
            // 
            resources.ApplyResources(this.userTypeComboBox, "userTypeComboBox");
            this.userTypeComboBox.FormattingEnabled = true;
            this.userTypeComboBox.Name = "userTypeComboBox";
            this.userTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.userTypeComboBox_SelectedIndexChanged);
            // 
            // comboBoxLng
            // 
            resources.ApplyResources(this.comboBoxLng, "comboBoxLng");
            this.comboBoxLng.FormattingEnabled = true;
            this.comboBoxLng.Name = "comboBoxLng";
            this.comboBoxLng.SelectedIndexChanged += new System.EventHandler(this.comboBoxLng_SelectedIndexChanged);
            // 
            // changeLngBtn
            // 
            resources.ApplyResources(this.changeLngBtn, "changeLngBtn");
            this.changeLngBtn.Name = "changeLngBtn";
            this.changeLngBtn.UseVisualStyleBackColor = true;
            this.changeLngBtn.Click += new System.EventHandler(this.changeLngBtn_Click);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.changeLngBtn);
            this.Controls.Add(this.comboBoxLng);
            this.Controls.Add(this.userTypeComboBox);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.usernameTxtBox);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTxtBox;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.ComboBox userTypeComboBox;
        private System.Windows.Forms.ComboBox comboBoxLng;
        private System.Windows.Forms.Button changeLngBtn;
    }
}

