using Core.Models;
using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.BuilderPattern.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Director;
using MiniFacebookVisual.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniFacebookVisual
{
    public partial class Profile : Form
    {
        User user;
        ProxyFacebook proxy;
        public Profile()
        {
            InitializeComponent();
            user = MainView.user;
            proxy = MainView.proxy;
            user = proxy.GetUserById(user.ID);
            user.friends = proxy.GetFriends(user.ID);
            completeNameLabel.Text = user.firstName + " " + user.lastName;
            dateJoinedLabel.Text = user.dateJoined.ToString("MMMM") + " " + user.dateJoined.Year.ToString();
            birthdayDateLabel.Text = user.birthday.Day.ToString() + " de " + user.birthday.ToString("MMMM");
            profilePictureImage.Image = Image.FromFile(user.profilePicture);
            nameBtn.Text = user.firstName;
            countFriendsLabel.Text = user.friends.Count.ToString();
            var feedCooker = new FeedCooker(new BuilderProfileFeed(this.refresh, this, postPanel, user.ID, user.ID, proxy));
            feedCooker.ObtenerFeed();
            if (postPanel.Controls.Count < 2)
            {
                noPostLbl.Text = "Sin actividad en tu perfil.";
            }
        }

        public void refresh()
        {
            noPostLbl.Text = "";
            int scroll = postPanel.VerticalScroll.Value;
            postPanel.Controls.Clear();
            var feedCooker = new FeedCooker(new BuilderProfileFeed(this.refresh, this, postPanel, user.ID, user.ID, proxy));
            feedCooker.ObtenerFeed();
            postPanel.VerticalScroll.Value = scroll;
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
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

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void miembroDesdeLabel_Click(object sender, EventArgs e)
        {

        }

        private void profilePictureImage_Click(object sender, EventArgs e)
        {

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

        private void friendsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FriendList(user);
            next.ShowDialog();
            this.Close();
        }

        private void editProfileBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new EditProfile();
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
    }
}
