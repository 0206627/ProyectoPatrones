using Core.Models;
using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Views
{
    public partial class EditProfile : Form
    {
        string imageLocation;
        User user;
        ProxyFacebook proxy;
        public EditProfile()
        {
            user = MainView.user;
            proxy = MainView.proxy;
            user = proxy.GetUserById(user.ID);
            InitializeComponent();
            nameRegisterTxt.Text = user.firstName;
            lastNameRegisterTxt.Text = user.lastName;
            profilePictureImage.Image = Image.FromFile(user.profilePicture);
            imageLocation = user.profilePicture;
            nameBtn.Text = user.firstName;
        }

        private void selectImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    profilePictureImage.Image = Image.FromFile(imageLocation);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pwdChangeText_TextChanged(object sender, EventArgs e)
        {
            pwdChangeText.ForeColor = Color.Black;
            pwdChangeText.UseSystemPasswordChar = true;
        }

        private void pwdChangeCheckTxt_TextChanged(object sender, EventArgs e)
        {
            pwdChangeCheckTxt.ForeColor = Color.Black;
            pwdChangeCheckTxt.UseSystemPasswordChar = true;
        }

        private void guardarBtn_Click(object sender, EventArgs e)
        {
            if (pwdChangeText.Text != "Nueva contraseña" && pwdChangeText.Text != "" && pwdChangeCheckTxt.Text != "Validar Nueva Contraseña" && pwdChangeCheckTxt.Text != "" )
            {
                if (pwdChangeCheckTxt.Text != pwdChangeText.Text)
                {
                    MessageBox.Show("Contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pwdChangeCheckTxt.Text = "Validar Nueva Contraseña";
                    pwdChangeCheckTxt.ForeColor = SystemColors.ControlDark;
                    pwdChangeCheckTxt.UseSystemPasswordChar = false;
                    pwdChangeText.Text = "Nueva contraseña";
                    pwdChangeText.ForeColor = SystemColors.ControlDark;
                    pwdChangeText.UseSystemPasswordChar = false;
                    return;
                }

                if (pwdChangeText.Text == user.pwd)
                {
                    MessageBox.Show("Nueva contraseña no puede ser igual a la anterior.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pwdChangeCheckTxt.Text = "Validar Nueva Contraseña";
                    pwdChangeCheckTxt.ForeColor = SystemColors.ControlDark;
                    pwdChangeCheckTxt.UseSystemPasswordChar = false;
                    pwdChangeText.Text = "Nueva contraseña";
                    pwdChangeText.ForeColor = SystemColors.ControlDark;
                    pwdChangeText.UseSystemPasswordChar = false;
                    return;
                }

                bool res = proxy.ChangeUser(user.ID, nameRegisterTxt.Text, lastNameRegisterTxt.Text, pwdChangeText.Text, imageLocation);

                if (res)
                {
                    this.Hide();
                    Form next = new Profile();
                    next.ShowDialog();
                    this.Close();
                } else
                {
                    MessageBox.Show("Error al realizar cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                bool res = proxy.ChangeUser(user.ID, nameRegisterTxt.Text, lastNameRegisterTxt.Text, user.pwd, imageLocation);

                if (res)
                {
                    this.Hide();
                    Form next = new Profile();
                    next.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al realizar cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nameBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new Profile();
            next.ShowDialog();
            this.Close();
        }

        private void friendBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FriendRequest();
            next.ShowDialog();
            this.Close();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new MainView();
            next.ShowDialog();
            this.Close();
        }

        private void feedBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FeedView();
            next.ShowDialog();
            this.Close();
        }

        private void profilePictureImage_Click(object sender, EventArgs e)
        {

        }
    }
}
