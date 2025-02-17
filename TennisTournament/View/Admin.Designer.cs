namespace TennisTournament.View
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.logoutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.updateUserPasswordBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            resources.ApplyResources(this.logoutBtn, "logoutBtn");
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // usersDataGridView
            // 
            resources.ApplyResources(this.usersDataGridView, "usersDataGridView");
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.userType,
            this.username});
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.RowTemplate.Height = 40;
            // 
            // id
            // 
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            // 
            // userType
            // 
            resources.ApplyResources(this.userType, "userType");
            this.userType.Name = "userType";
            // 
            // username
            // 
            resources.ApplyResources(this.username, "username");
            this.username.Name = "username";
            // 
            // updatedPasswordTxtBox
            // 
            resources.ApplyResources(this.updatedPasswordTxtBox, "updatedPasswordTxtBox");
            this.updatedPasswordTxtBox.Name = "updatedPasswordTxtBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // updateUserPasswordBtn
            // 
            resources.ApplyResources(this.updateUserPasswordBtn, "updateUserPasswordBtn");
            this.updateUserPasswordBtn.Name = "updateUserPasswordBtn";
            this.updateUserPasswordBtn.UseVisualStyleBackColor = true;
            this.updateUserPasswordBtn.Click += new System.EventHandler(this.updateUserPasswordBtn_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // deleteUserBtn
            // 
            resources.ApplyResources(this.deleteUserBtn, "deleteUserBtn");
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.UseVisualStyleBackColor = true;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // Admin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteUserBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updateUserPasswordBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updatedPasswordTxtBox);
            this.Controls.Add(this.usersDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutBtn);
            this.Name = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn userType;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.TextBox updatedPasswordTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateUserPasswordBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button deleteUserBtn;
    }
}