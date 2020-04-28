using Core_API.Models;

using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.BuilderPattern.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Director;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual
{
    public partial class OtherProfile : Form
    {
        User user;
        ProxyFacebook proxy;
        User otherUser;
        bool checkFriendship;
        bool checkRequest;
        bool checkInversedRequest;
        public OtherProfile(int otherUserID)
        {
            InitializeComponent();
            user = MainView.user;
            proxy = MainView.proxy;
            otherUser = proxy.GetUserById(otherUserID);
            user = proxy.GetUserById(user.ID);
            checkFriendship = proxy.CheckFriendship(user.ID, otherUser.ID);
            checkRequest = proxy.CheckRequest(user.ID, otherUser.ID);
            checkInversedRequest = proxy.CheckRequest(otherUser.ID, user.ID);
            completeNameLabel.Text = otherUser.firstName + " " + otherUser.lastName;
            dateJoinedLabel.Text = otherUser.dateJoined.ToString("MMMM") + " " + otherUser.dateJoined.Year.ToString();
            birthdayDateLabel.Text = otherUser.birthday.Day.ToString() + " de " + otherUser.birthday.ToString("MMMM");
            profilePictureImage.Image = Image.FromFile(otherUser.profilePicture);
            nameBtn.Text = user.firstName;
            if (checkRequest) friendsBtn.Text = "Aceptar solicitud";
            else if (checkInversedRequest) friendsBtn.Text = "Cancelar solicitud";
            else if (!checkFriendship) friendsBtn.Text = "Añadir amigo";
            else friendsBtn.Text = "Eliminar amigo";
            var feedCooker = new FeedCooker(new BuilderProfileFeed(this.refresh, this, postPanel, user.ID, otherUser.ID, proxy));
            feedCooker.ObtenerFeed();
        }

        public void refresh()
        {
            int scroll = postPanel.VerticalScroll.Value;
            postPanel.Controls.Clear();
            var feedCooker = new FeedCooker(new BuilderProfileFeed(this.refresh, this, postPanel, user.ID, otherUser.ID, proxy));
            feedCooker.ObtenerFeed();
            postPanel.VerticalScroll.Value = scroll;
        }

        private void nameBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new Profile();
            next.ShowDialog();
            this.Close();
        }

        private void completeNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text != "")
            {
                this.Hide();
                Form next = new FriendSearch(searchTxt.Text);
                next.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Rellenar búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void friendBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FriendRequest();
            next.ShowDialog();
            this.Close();
        }

        private void friendsBtn_Click(object sender, EventArgs e)
        {
            if (friendsBtn.Text == "Aceptar solicitud")
            {
                bool check = proxy.CreateFriendship(user.ID, otherUser.ID);

                if (check)
                {
                    this.Hide();
                    Form next = new OtherProfile(otherUser.ID);
                    next.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } else if (friendsBtn.Text == "Eliminar amigo")
            {

                if (MessageBox.Show($"¿Seguro que quieres eliminar a {otherUser.firstName}?", "Eliminar amigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    bool check = proxy.DeleteFriendship(user.ID, otherUser.ID);

                    if (check)
                    {
                        this.Hide();
                        Form next = new OtherProfile(otherUser.ID);
                        next.ShowDialog();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Error al eliminar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (friendsBtn.Text == "Añadir amigo")
            {
                bool check = proxy.CreateFriendRequest(otherUser.ID, user.ID);

                if (check)
                {
                    this.Hide();
                    Form next = new OtherProfile(otherUser.ID);
                    next.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al mandar solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  else
            {
                if (MessageBox.Show($"¿Seguro que quieres cancelar la solicitud de amistad a {otherUser.firstName}?", "Cancelar solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool check = proxy.DeleteFriendshipRequest(otherUser.ID, user.ID);

                    if (check)
                    {
                        this.Hide();
                        Form next = new OtherProfile(otherUser.ID);
                        next.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

        private void bannerImage_Click(object sender, EventArgs e)
        {

        }

        private void OtherProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
