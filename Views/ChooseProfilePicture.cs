using Core.Models;
using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual
{
    public partial class ChooseProfilePicture : Form
    {
        User user;
        ProxyFacebook proxy;
        string imageLocation;
        public ChooseProfilePicture()
        {
            InitializeComponent();
            user = MainView.user;
            proxy = MainView.proxy;
            imageLocation = "";

            nameLabel.Text = user.firstName;

            imageLocation = "C:\\Users\\Mariana De la Vega\\Desktop\\Patrones\\MiniFacebookVisual\\images\\profileIcon.png";
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

            } catch (Exception)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guardarBtn_Click(object sender, EventArgs e)
        {
            bool res = proxy.AddProfilePicture(imageLocation, user.ID);

            if (res)
            {
                this.Hide();
                Form next = new Profile();
                next.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void ChooseProfilePicture_Load(object sender, EventArgs e)
        {

        }
    }
}
