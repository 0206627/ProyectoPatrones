namespace MiniFacebookVisual
{
    partial class MainView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.hiddenLabel = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.manRegisterRadioBtn = new System.Windows.Forms.RadioButton();
            this.womanRegisterRadioBtn = new System.Windows.Forms.RadioButton();
            this.genderLabel = new System.Windows.Forms.Label();
            this.brithdayLabel = new System.Windows.Forms.Label();
            this.birthdayRegisterTxt = new System.Windows.Forms.DateTimePicker();
            this.pwdRegisterTxt = new System.Windows.Forms.TextBox();
            this.emailRegisterTxt = new System.Windows.Forms.TextBox();
            this.lastNameRegisterTxt = new System.Windows.Forms.TextBox();
            this.nameRegisterTxt = new System.Windows.Forms.TextBox();
            this.registerLabel = new System.Windows.Forms.Label();
            this.registerImage = new System.Windows.Forms.PictureBox();
            this.forgottenLabel = new System.Windows.Forms.Label();
            this.miniFacebookLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.logInBtn = new System.Windows.Forms.Button();
            this.pwdText = new System.Windows.Forms.TextBox();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.bannerImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.registerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // hiddenLabel
            // 
            this.hiddenLabel.AutoSize = true;
            this.hiddenLabel.Location = new System.Drawing.Point(571, 918);
            this.hiddenLabel.Name = "hiddenLabel";
            this.hiddenLabel.Size = new System.Drawing.Size(0, 25);
            this.hiddenLabel.TabIndex = 52;
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(150)))), ((int)(((byte)(74)))));
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.ForeColor = System.Drawing.Color.White;
            this.registerBtn.Location = new System.Drawing.Point(914, 758);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(266, 64);
            this.registerBtn.TabIndex = 51;
            this.registerBtn.Text = "Registrarte";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // manRegisterRadioBtn
            // 
            this.manRegisterRadioBtn.AutoSize = true;
            this.manRegisterRadioBtn.Location = new System.Drawing.Point(1062, 678);
            this.manRegisterRadioBtn.Name = "manRegisterRadioBtn";
            this.manRegisterRadioBtn.Size = new System.Drawing.Size(118, 29);
            this.manRegisterRadioBtn.TabIndex = 50;
            this.manRegisterRadioBtn.TabStop = true;
            this.manRegisterRadioBtn.Text = "Hombre";
            this.manRegisterRadioBtn.UseVisualStyleBackColor = true;
            this.manRegisterRadioBtn.CheckedChanged += new System.EventHandler(this.manRegisterRadioBtn_CheckedChanged);
            // 
            // womanRegisterRadioBtn
            // 
            this.womanRegisterRadioBtn.AutoSize = true;
            this.womanRegisterRadioBtn.Location = new System.Drawing.Point(924, 678);
            this.womanRegisterRadioBtn.Name = "womanRegisterRadioBtn";
            this.womanRegisterRadioBtn.Size = new System.Drawing.Size(97, 29);
            this.womanRegisterRadioBtn.TabIndex = 49;
            this.womanRegisterRadioBtn.TabStop = true;
            this.womanRegisterRadioBtn.Text = "Mujer";
            this.womanRegisterRadioBtn.UseVisualStyleBackColor = true;
            this.womanRegisterRadioBtn.CheckedChanged += new System.EventHandler(this.womanRegisterRadioBtn_CheckedChanged);
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.genderLabel.Location = new System.Drawing.Point(919, 624);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(61, 25);
            this.genderLabel.TabIndex = 48;
            this.genderLabel.Text = "Sexo";
            this.genderLabel.Click += new System.EventHandler(this.genderLabel_Click);
            // 
            // brithdayLabel
            // 
            this.brithdayLabel.AutoSize = true;
            this.brithdayLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.brithdayLabel.Location = new System.Drawing.Point(919, 522);
            this.brithdayLabel.Name = "brithdayLabel";
            this.brithdayLabel.Size = new System.Drawing.Size(212, 25);
            this.brithdayLabel.TabIndex = 47;
            this.brithdayLabel.Text = "Fecha de nacimiento";
            this.brithdayLabel.Click += new System.EventHandler(this.brithdayLabel_Click);
            // 
            // birthdayRegisterTxt
            // 
            this.birthdayRegisterTxt.Location = new System.Drawing.Point(919, 568);
            this.birthdayRegisterTxt.Name = "birthdayRegisterTxt";
            this.birthdayRegisterTxt.Size = new System.Drawing.Size(439, 31);
            this.birthdayRegisterTxt.TabIndex = 46;
            this.birthdayRegisterTxt.ValueChanged += new System.EventHandler(this.birthdayRegisterTxt_ValueChanged);
            // 
            // pwdRegisterTxt
            // 
            this.pwdRegisterTxt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.pwdRegisterTxt.Location = new System.Drawing.Point(919, 458);
            this.pwdRegisterTxt.Name = "pwdRegisterTxt";
            this.pwdRegisterTxt.Size = new System.Drawing.Size(620, 31);
            this.pwdRegisterTxt.TabIndex = 45;
            this.pwdRegisterTxt.Text = "Contraseña";
            this.pwdRegisterTxt.TextChanged += new System.EventHandler(this.pwdRegisterTxt_TextChanged);
            // 
            // emailRegisterTxt
            // 
            this.emailRegisterTxt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.emailRegisterTxt.Location = new System.Drawing.Point(919, 406);
            this.emailRegisterTxt.Name = "emailRegisterTxt";
            this.emailRegisterTxt.Size = new System.Drawing.Size(620, 31);
            this.emailRegisterTxt.TabIndex = 44;
            this.emailRegisterTxt.Text = "Correo electrónico";
            this.emailRegisterTxt.TextChanged += new System.EventHandler(this.emailRegisterTxt_TextChanged);
            // 
            // lastNameRegisterTxt
            // 
            this.lastNameRegisterTxt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lastNameRegisterTxt.Location = new System.Drawing.Point(1242, 355);
            this.lastNameRegisterTxt.Name = "lastNameRegisterTxt";
            this.lastNameRegisterTxt.Size = new System.Drawing.Size(297, 31);
            this.lastNameRegisterTxt.TabIndex = 43;
            this.lastNameRegisterTxt.Text = "Apellidos";
            this.lastNameRegisterTxt.TextChanged += new System.EventHandler(this.lastNameRegisterTxt_TextChanged);
            // 
            // nameRegisterTxt
            // 
            this.nameRegisterTxt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.nameRegisterTxt.Location = new System.Drawing.Point(919, 355);
            this.nameRegisterTxt.Name = "nameRegisterTxt";
            this.nameRegisterTxt.Size = new System.Drawing.Size(297, 31);
            this.nameRegisterTxt.TabIndex = 42;
            this.nameRegisterTxt.Text = "Nombre";
            this.nameRegisterTxt.TextChanged += new System.EventHandler(this.nameRegisterTxt_TextChanged);
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLabel.Location = new System.Drawing.Point(903, 214);
            this.registerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(411, 91);
            this.registerLabel.TabIndex = 41;
            this.registerLabel.Text = "Regístrate";
            this.registerLabel.Click += new System.EventHandler(this.registerLabel_Click);
            // 
            // registerImage
            // 
            this.registerImage.Image = ((System.Drawing.Image)(resources.GetObject("registerImage.Image")));
            this.registerImage.Location = new System.Drawing.Point(113, 239);
            this.registerImage.Margin = new System.Windows.Forms.Padding(6);
            this.registerImage.Name = "registerImage";
            this.registerImage.Size = new System.Drawing.Size(666, 606);
            this.registerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.registerImage.TabIndex = 40;
            this.registerImage.TabStop = false;
            this.registerImage.Click += new System.EventHandler(this.registerImage_Click);
            // 
            // forgottenLabel
            // 
            this.forgottenLabel.AutoSize = true;
            this.forgottenLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.forgottenLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.forgottenLabel.Location = new System.Drawing.Point(997, 127);
            this.forgottenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forgottenLabel.Name = "forgottenLabel";
            this.forgottenLabel.Size = new System.Drawing.Size(378, 25);
            this.forgottenLabel.TabIndex = 39;
            this.forgottenLabel.Text = "¿Has olvidado los datos de la cuenta?";
            this.forgottenLabel.Click += new System.EventHandler(this.forgottenLabel_Click);
            // 
            // miniFacebookLabel
            // 
            this.miniFacebookLabel.AutoSize = true;
            this.miniFacebookLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.miniFacebookLabel.Font = new System.Drawing.Font("Bahnschrift", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniFacebookLabel.ForeColor = System.Drawing.Color.White;
            this.miniFacebookLabel.Location = new System.Drawing.Point(101, 44);
            this.miniFacebookLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.miniFacebookLabel.Name = "miniFacebookLabel";
            this.miniFacebookLabel.Size = new System.Drawing.Size(382, 71);
            this.miniFacebookLabel.TabIndex = 38;
            this.miniFacebookLabel.Text = "minifacebook";
            this.miniFacebookLabel.Click += new System.EventHandler(this.miniFacebookLabel_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.emailLabel.ForeColor = System.Drawing.Color.White;
            this.emailLabel.Location = new System.Drawing.Point(649, 33);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(188, 25);
            this.emailLabel.TabIndex = 33;
            this.emailLabel.Text = "Correo electrónico";
            this.emailLabel.Click += new System.EventHandler(this.emailLabel_Click);
            // 
            // logInBtn
            // 
            this.logInBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(130)))));
            this.logInBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.logInBtn.FlatAppearance.BorderSize = 10;
            this.logInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInBtn.ForeColor = System.Drawing.Color.White;
            this.logInBtn.Location = new System.Drawing.Point(1421, 66);
            this.logInBtn.Margin = new System.Windows.Forms.Padding(4);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(118, 40);
            this.logInBtn.TabIndex = 36;
            this.logInBtn.Text = "Entrar";
            this.logInBtn.UseVisualStyleBackColor = false;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // pwdText
            // 
            this.pwdText.Location = new System.Drawing.Point(1001, 75);
            this.pwdText.Margin = new System.Windows.Forms.Padding(4);
            this.pwdText.MaxLength = 100;
            this.pwdText.Name = "pwdText";
            this.pwdText.PasswordChar = '*';
            this.pwdText.Size = new System.Drawing.Size(296, 31);
            this.pwdText.TabIndex = 35;
            this.pwdText.UseSystemPasswordChar = true;
            this.pwdText.TextChanged += new System.EventHandler(this.pwdText_TextChanged);
            // 
            // pwdLabel
            // 
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(52)))), ((int)(((byte)(107)))));
            this.pwdLabel.ForeColor = System.Drawing.Color.White;
            this.pwdLabel.Location = new System.Drawing.Point(997, 33);
            this.pwdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(123, 25);
            this.pwdLabel.TabIndex = 34;
            this.pwdLabel.Text = "Contraseña";
            this.pwdLabel.Click += new System.EventHandler(this.pwdLabel_Click);
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(645, 75);
            this.emailTxt.Margin = new System.Windows.Forms.Padding(4);
            this.emailTxt.MaxLength = 100;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(296, 31);
            this.emailTxt.TabIndex = 32;
            this.emailTxt.TextChanged += new System.EventHandler(this.emailTxt_TextChanged);
            // 
            // bannerImage
            // 
            this.bannerImage.Image = ((System.Drawing.Image)(resources.GetObject("bannerImage.Image")));
            this.bannerImage.Location = new System.Drawing.Point(-25, -2);
            this.bannerImage.Margin = new System.Windows.Forms.Padding(4);
            this.bannerImage.Name = "bannerImage";
            this.bannerImage.Size = new System.Drawing.Size(1696, 179);
            this.bannerImage.TabIndex = 37;
            this.bannerImage.TabStop = false;
            this.bannerImage.Click += new System.EventHandler(this.bannerImage_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1646, 969);
            this.Controls.Add(this.hiddenLabel);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.manRegisterRadioBtn);
            this.Controls.Add(this.womanRegisterRadioBtn);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.brithdayLabel);
            this.Controls.Add(this.birthdayRegisterTxt);
            this.Controls.Add(this.pwdRegisterTxt);
            this.Controls.Add(this.emailRegisterTxt);
            this.Controls.Add(this.lastNameRegisterTxt);
            this.Controls.Add(this.nameRegisterTxt);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.registerImage);
            this.Controls.Add(this.forgottenLabel);
            this.Controls.Add(this.miniFacebookLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.pwdText);
            this.Controls.Add(this.pwdLabel);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.bannerImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "minifacebook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bannerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hiddenLabel;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.RadioButton manRegisterRadioBtn;
        private System.Windows.Forms.RadioButton womanRegisterRadioBtn;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label brithdayLabel;
        private System.Windows.Forms.DateTimePicker birthdayRegisterTxt;
        private System.Windows.Forms.TextBox pwdRegisterTxt;
        private System.Windows.Forms.TextBox emailRegisterTxt;
        private System.Windows.Forms.TextBox lastNameRegisterTxt;
        private System.Windows.Forms.TextBox nameRegisterTxt;
        internal System.Windows.Forms.Label registerLabel;
        internal System.Windows.Forms.PictureBox registerImage;
        internal System.Windows.Forms.Label forgottenLabel;
        internal System.Windows.Forms.Label miniFacebookLabel;
        internal System.Windows.Forms.Label emailLabel;
        internal System.Windows.Forms.Button logInBtn;
        internal System.Windows.Forms.TextBox pwdText;
        internal System.Windows.Forms.Label pwdLabel;
        internal System.Windows.Forms.TextBox emailTxt;
        internal System.Windows.Forms.PictureBox bannerImage;
    }
}

