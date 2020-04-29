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
    public partial class TagFriends : Form
    {
        User user;
        ProxyFacebook proxy;
        public static List<int> tagID = new List<int>();
        public static List<string> tagged = new List<string>();
        public TagFriends()
        {
            user = MainView.user;
            proxy = MainView.proxy;
            user = proxy.GetUserById(user.ID);
            user.friends = proxy.GetFriends(user.ID);
            InitializeComponent();
        }

        private void friendTextBox_TextChanged(object sender, EventArgs e)
        {
            friendTextBox.ForeColor = Color.Black;
        }

        private void AutoComplete()
        {
            friendTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            friendTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            foreach (User user in user.friends)
            {
                friendTextBox.AutoCompleteCustomSource.Add($"{user.firstName} {user.lastName}");
            }
            
        }

        private void TagFriends_Load(object sender, EventArgs e)
        {
            AutoComplete();
        }

        private void tagBtn_Click(object sender, EventArgs e)
        {
            tagID.Add(proxy.AddTag(friendTextBox.Text));
            if (tagID.Last() < 0)
            {
                MessageBox.Show("Ya has etiquetado a ese amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!(tagID.Last() != 0))
            {
                MessageBox.Show("Error al etiquetar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                tagged.Add(friendTextBox.Text);
                this.Close();
            }
        }
    }
}
