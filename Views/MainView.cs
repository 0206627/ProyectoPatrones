using Core_API.Models;
using DAL_API.Chain_of_Responsibility;
using MiniFacebookVisual.Models;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MiniFacebookVisual
{
    public partial class MainView : Form
    {
        public static User user;
        public static ProxyFacebook proxy = new ProxyFacebook();
        public MainView()
        {
            InitializeComponent();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {

            bool correct = false;
            int res = 0;

            if (emailTxt.Text != "" && pwdText.Text != "")
            {
                string pattern = "^([0-9a-zA-z]([-\\.\\w]*[0-9a-zA-z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)" +
                    "[a-zA-Z]{2,9})$";

                if (!Regex.IsMatch(emailTxt.Text, pattern))
                {
                    MessageBox.Show("Escribir un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var logIn = new LogIn(emailTxt.Text, pwdText.Text);
                var emailHandler = new EmailHandler();
                var pwdHandler = new PasswordHandler();

                emailHandler.SetNext(pwdHandler);
                res = Convert.ToInt32(ClientHandler.ClientCode(emailHandler, logIn));

                if (res != 0) correct = true;
            }
            else
            {
                MessageBox.Show("Rellenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!correct)
            {
                MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pwdText.Clear();
                return;

            }
            else
            {
                MessageBox.Show("ID: " + res.ToString());
                user = proxy.GetUserById(res);
            }

            user.friends = proxy.GetFriends(user.ID);

            this.Hide();
            Form next = new FeedView();
            next.ShowDialog();
            this.Close();
        }

        private void emailTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pwdText_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            bool valid = false;

            if ((nameRegisterTxt.Text != "Nombre" && nameRegisterTxt.Text != null) && (lastNameRegisterTxt.Text != "Apellidos" && lastNameRegisterTxt.Text != null) && (emailRegisterTxt.Text != "Correo electrónico" && emailRegisterTxt.Text != "null") && (pwdRegisterTxt.Text != "Contraseña" && pwdRegisterTxt.Text != null) && (womanRegisterRadioBtn.Checked || manRegisterRadioBtn.Checked))
            {
                string pattern = "^([0-9a-zA-z]([-\\.\\w]*[0-9a-zA-z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)" +
                    "[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(emailRegisterTxt.Text, pattern)) valid = true;
                else
                {
                    MessageBox.Show("Correo electrónico inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                    return;
                }

                if (pwdRegisterTxt.Text.Length > 7) valid = true;
                else
                {
                    MessageBox.Show("Tu contraseña debe tener al menos 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                    pwdRegisterTxt.Text = "Contraseña";
                    pwdRegisterTxt.UseSystemPasswordChar = false;
                    pwdRegisterTxt.ForeColor = SystemColors.InactiveCaption;
         
                    return;
                }

                var ts = DateTime.Now - birthdayRegisterTxt.Value;
                var year = Convert.ToInt32(DateTime.MinValue.Add(ts).Year);
                if (year > 0) year -= 1;

                if (year >= 15 && year <= 100) valid = true;
                else
                {
                    valid = false;
                    MessageBox.Show("Ingresar una fecha de nacimiento válida. Tener al menos 15 años de edad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Rellenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }

            if (valid)
            {
                string gender;
                if (womanRegisterRadioBtn.Checked) gender = "Mujer";
                else gender = "Hombre";

                bool existing = proxy.CheckExistingUser(emailRegisterTxt.Text);

                if (!existing)
                {
                    int res = proxy.Register(nameRegisterTxt.Text, lastNameRegisterTxt.Text, emailRegisterTxt.Text, pwdRegisterTxt.Text, gender, birthdayRegisterTxt.Value);

                    if (res != 0)
                    {
                        valid = true;
                        MessageBox.Show("ID " + res.ToString());
                        user = proxy.GetUserById(res);
                    }
                    else
                    {
                        valid = false;
                        MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    user.friends = proxy.GetFriends(user.ID);

                    this.Hide();
                    Form next = new ChooseProfilePicture();
                    next.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Correo electrónico ya utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    emailRegisterTxt.Text = "Correo electrónico";
                    emailRegisterTxt.ForeColor = SystemColors.InactiveCaption;
                    pwdRegisterTxt.Text = "Contraseña";
                    pwdRegisterTxt.UseSystemPasswordChar = false;
                    pwdRegisterTxt.ForeColor = SystemColors.InactiveCaption;

                }
            }

        }

        private void womanRegisterRadioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void manRegisterRadioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void birthdayRegisterTxt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pwdRegisterTxt_TextChanged(object sender, EventArgs e)
        {
            pwdRegisterTxt.ForeColor = Color.Black;
            pwdRegisterTxt.UseSystemPasswordChar = true;
        }

        private void emailRegisterTxt_TextChanged(object sender, EventArgs e)
        {
            emailRegisterTxt.ForeColor = Color.Black;
        }

        private void nameRegisterTxt_TextChanged(object sender, EventArgs e)
        {
            nameRegisterTxt.ForeColor = Color.Black;
        }

        private void lastNameRegisterTxt_TextChanged(object sender, EventArgs e)
        {
            lastNameRegisterTxt.ForeColor = Color.Black;
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {

        }

        private void registerImage_Click(object sender, EventArgs e)
        {

        }

        private void miniFacebookLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void pwdLabel_Click(object sender, EventArgs e)
        {

        }

        private void forgottenLabel_Click(object sender, EventArgs e)
        {

        }

        private void bannerImage_Click(object sender, EventArgs e)
        {

        }

        private void brithdayLabel_Click(object sender, EventArgs e)
        {

        }

        private void genderLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
