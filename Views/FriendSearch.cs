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
    public partial class FriendSearch : Form
    {
        User user;
        List<User> searchList;
        ProxyFacebook proxy;
        FriendSearchResult result;
        public FriendSearch(string search)
        {
            InitializeComponent();
            nameResultLabel.Text = search;
            user = MainView.user;
            proxy = MainView.proxy;
            user = proxy.GetUserById(user.ID);
            searchList = proxy.SearchUsers(search, user.ID);
            nameBtn.Text = user.firstName;
            result = new FriendSearchResult(this, resultsPanel, user.ID, searchList, proxy, search);
            result.AddResults();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nameResultLabel_Click(object sender, EventArgs e)
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
            } else
            {
                MessageBox.Show("Rellenar búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewProfileBtn_Click(object sender, EventArgs e)
        {

        }

        private void FriendSearch_Load(object sender, EventArgs e)
        {
            //this.Size = new Size(1759, 1433);
        }

        private void resultsLabel_Click(object sender, EventArgs e)
        {

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
