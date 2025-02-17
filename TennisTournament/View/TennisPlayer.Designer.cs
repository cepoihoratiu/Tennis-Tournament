namespace TennisTournament.View
{
    partial class TennisPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TennisPlayer));
            this.logoutBtn = new System.Windows.Forms.Button();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.surnameTxtBox = new System.Windows.Forms.TextBox();
            this.nationalityComboBox = new System.Windows.Forms.ComboBox();
            this.updateTennisPlayerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dataGridViewFixture = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFixture)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            resources.ApplyResources(this.logoutBtn, "logoutBtn");
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // nameTxtBox
            // 
            resources.ApplyResources(this.nameTxtBox, "nameTxtBox");
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.TextChanged += new System.EventHandler(this.nameTxtBox_TextChanged);
            // 
            // surnameTxtBox
            // 
            resources.ApplyResources(this.surnameTxtBox, "surnameTxtBox");
            this.surnameTxtBox.Name = "surnameTxtBox";
            this.surnameTxtBox.TextChanged += new System.EventHandler(this.surnameTxtBox_TextChanged);
            // 
            // nationalityComboBox
            // 
            this.nationalityComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.nationalityComboBox, "nationalityComboBox");
            this.nationalityComboBox.Name = "nationalityComboBox";
            this.nationalityComboBox.SelectedIndexChanged += new System.EventHandler(this.nationalityComboBox_SelectedIndexChanged);
            // 
            // updateTennisPlayerBtn
            // 
            resources.ApplyResources(this.updateTennisPlayerBtn, "updateTennisPlayerBtn");
            this.updateTennisPlayerBtn.Name = "updateTennisPlayerBtn";
            this.updateTennisPlayerBtn.UseVisualStyleBackColor = true;
            this.updateTennisPlayerBtn.Click += new System.EventHandler(this.updateTennisPlayerBtn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // deleteBtn
            // 
            resources.ApplyResources(this.deleteBtn, "deleteBtn");
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // dataGridViewFixture
            // 
            this.dataGridViewFixture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridViewFixture, "dataGridViewFixture");
            this.dataGridViewFixture.Name = "dataGridViewFixture";
            this.dataGridViewFixture.RowTemplate.Height = 40;
            this.dataGridViewFixture.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFixture_CellContentClick);
            // 
            // TennisPlayer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewFixture);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateTennisPlayerBtn);
            this.Controls.Add(this.nationalityComboBox);
            this.Controls.Add(this.surnameTxtBox);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.logoutBtn);
            this.Name = "TennisPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFixture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.TextBox surnameTxtBox;
        private System.Windows.Forms.ComboBox nationalityComboBox;
        private System.Windows.Forms.Button updateTennisPlayerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridView dataGridViewFixture;
    }
}