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
    public partial class FriendRequest : Form
    {
        User user;
        List<User> requestList;
        ProxyFacebook proxy;
        FriendRequestCustom result;
        public FriendRequest()
        {
            InitializeComponent();
            user = MainView.user;
            proxy = MainView.proxy;
            user = proxy.GetUserById(user.ID);
            requestList = proxy.GetFriendRequests(user.ID);
            nameBtn.Text = user.firstName;
            result = new FriendRequestCustom(this, resultsPanel, user.ID, requestList, proxy);
            result.AddResults();
        }

        private void resultsLabel_Click(object sender, EventArgs e)
        {

        }

        private void friendBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FriendRequest();
            next.ShowDialog();
            this.Close();
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
    }
}
