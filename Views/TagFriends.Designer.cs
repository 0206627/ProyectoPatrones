namespace MiniFacebookVisual.Views
{
    partial class TagFriends
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
            this.friendTextBox = new System.Windows.Forms.TextBox();
            this.tagBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // friendTextBox
            // 
            this.friendTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.friendTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.friendTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.friendTextBox.Location = new System.Drawing.Point(124, 115);
            this.friendTextBox.Name = "friendTextBox";
            this.friendTextBox.Size = new System.Drawing.Size(793, 31);
            this.friendTextBox.TabIndex = 0;
            this.friendTextBox.TextChanged += new System.EventHandler(this.friendTextBox_TextChanged);
            // 
            // tagBtn
            // 
            this.tagBtn.AutoSize = true;
            this.tagBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.tagBtn.FlatAppearance.BorderSize = 0;
            this.tagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tagBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagBtn.ForeColor = System.Drawing.Color.White;
            this.tagBtn.Location = new System.Drawing.Point(777, 180);
            this.tagBtn.Name = "tagBtn";
            this.tagBtn.Size = new System.Drawing.Size(140, 46);
            this.tagBtn.TabIndex = 1;
            this.tagBtn.Text = "Etiquetar";
            this.tagBtn.UseVisualStyleBackColor = false;
            this.tagBtn.Click += new System.EventHandler(this.tagBtn_Click);
            // 
            // TagFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 300);
            this.Controls.Add(this.tagBtn);
            this.Controls.Add(this.friendTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TagFriends";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etiquetar Amigos";
            this.Load += new System.EventHandler(this.TagFriends_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox friendTextBox;
        private System.Windows.Forms.Button tagBtn;
    }
}