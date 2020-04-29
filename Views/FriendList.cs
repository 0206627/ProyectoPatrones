using Core_API.Models;
using MiniFacebookVisual.CustomViews;
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

namespace MiniFacebookVisual
{
    public partial class FriendList : Form
    {
        public User user;
        public ProxyFacebook proxy;
        public FriendListResult result;
        public FriendList(User user)
        {
            InitializeComponent();
            this.user = user;
            this.proxy = MainView.proxy;
            result = new FriendListResult(this, friendListPanel, user.ID, user.friends, proxy);
            result.AddResults();
            if (friendListPanel.Controls.Count < 2)
            {
                noPostLbl.Text = "Sin amigos.";
            } else
            {
                noPostLbl.Text = "";
            }
            nameBtn.Text = user.firstName;
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

        private void FriendList_Load(object sender, EventArgs e)
        {

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
