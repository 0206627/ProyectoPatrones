namespace MiniFacebookVisual
{
    partial class ChooseProfilePicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseProfilePicture));
            this.bienvenidoLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.profilePictureImage = new System.Windows.Forms.PictureBox();
            this.selectImageBtn = new System.Windows.Forms.Button();
            this.guardarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bienvenidoLabel
            // 
            this.bienvenidoLabel.AutoSize = true;
            this.bienvenidoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bienvenidoLabel.Location = new System.Drawing.Point(54, 54);
            this.bienvenidoLabel.Name = "bienvenidoLabel";
            this.bienvenidoLabel.Size = new System.Drawing.Size(331, 63);
            this.bienvenidoLabel.TabIndex = 0;
            this.bienvenidoLabel.Text = "Bienvenid@";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(55, 139);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(196, 55);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Nombre";
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // profilePictureImage
            // 
            this.profilePictureImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.profilePictureImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.profilePictureImage.Image = ((System.Drawing.Image)(resources.GetObject("profilePictureImage.Image")));
            this.profilePictureImage.Location = new System.Drawing.Point(507, 54);
            this.profilePictureImage.Name = "profilePictureImage";
            this.profilePictureImage.Size = new System.Drawing.Size(417, 386);
            this.profilePictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePictureImage.TabIndex = 2;
            this.profilePictureImage.TabStop = false;
            // 
            // selectImageBtn
            // 
            this.selectImageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.selectImageBtn.FlatAppearance.BorderSize = 0;
            this.selectImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectImageBtn.ForeColor = System.Drawing.Color.White;
            this.selectImageBtn.Location = new System.Drawing.Point(592, 463);
            this.selectImageBtn.Name = "selectImageBtn";
            this.selectImageBtn.Size = new System.Drawing.Size(253, 41);
            this.selectImageBtn.TabIndex = 3;
            this.selectImageBtn.Text = "Seleccionar imagen";
            this.selectImageBtn.UseVisualStyleBackColor = false;
            this.selectImageBtn.Click += new System.EventHandler(this.selectImageBtn_Click);
            // 
            // guardarBtn
            // 
            this.guardarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.guardarBtn.FlatAppearance.BorderSize = 0;
            this.guardarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarBtn.ForeColor = System.Drawing.Color.White;
            this.guardarBtn.Location = new System.Drawing.Point(132, 399);
            this.guardarBtn.Name = "guardarBtn";
            this.guardarBtn.Size = new System.Drawing.Size(253, 41);
            this.guardarBtn.TabIndex = 4;
            this.guardarBtn.Text = "Guardar cambios";
            this.guardarBtn.UseVisualStyleBackColor = false;
            this.guardarBtn.Click += new System.EventHandler(this.guardarBtn_Click);
            // 
            // ChooseProfilePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(991, 562);
            this.Controls.Add(this.guardarBtn);
            this.Controls.Add(this.selectImageBtn);
            this.Controls.Add(this.profilePictureImage);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.bienvenidoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseProfilePicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Perfil";
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bienvenidoLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox profilePictureImage;
        private System.Windows.Forms.Button selectImageBtn;
        private System.Windows.Forms.Button guardarBtn;
    }
}