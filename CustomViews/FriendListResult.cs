using Core_API.Models;
using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.CustomViews
{
    public class FriendListResult
    {
        private Form _form;
        private Panel _mainPanel;
        private int _userID;
        private ProxyFacebook _proxy;
        private List<User> _results;

        public FriendListResult(Form form, Panel panel, int userID, List<User> results, ProxyFacebook proxy)
        {
            this._mainPanel = panel;
            this._userID = userID;
            this._results = results;
            this._proxy = proxy;
            this._form = form;
        }

        public void AddResults()
        {
            int x = 25;
            int y = 20;

            foreach (User user in _results)
            {
                var temp = this.CreateItem(user, x, y);
                _mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 30;
            }

        }

        private Panel CreateItem(User user, int x, int y)
        {
            Panel temp = new Panel();
            temp.Location = new Point(x, y);
            temp.BorderStyle = BorderStyle.None;
            temp.ClientSize = new Size(1365 / 2, 187 / 2 - 10);

            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(5, 0);
            pic.Size = new Size(100, temp.Height);
            pic.BorderStyle = BorderStyle.None;
            pic.Image = Image.FromFile(user.profilePicture.ToString());

            Label nameLbl = new Label();
            nameLbl.Location = new Point(pic.Width + 15, pic.Location.Y + 30);
            nameLbl.Font = new Font(nameLbl.Font.FontFamily, 12, FontStyle.Bold);
            nameLbl.AutoSize = true;
            nameLbl.Text = $"{user.firstName} {user.lastName}";

            Button profileBtn = new Button();
            profileBtn.Text = "Ver perfil";
            profileBtn.ForeColor = Color.White;
            profileBtn.BackColor = Color.FromArgb(1, 52, 107);
            profileBtn.Location = new Point(pic.Width + 15 + 300, pic.Location.Y + 50);
            profileBtn.FlatAppearance.BorderSize = 0;
            profileBtn.FlatStyle = FlatStyle.Flat;
            profileBtn.Name = user.ID.ToString();
            profileBtn.Click += new EventHandler(profileBtnClick);

            Button friendBtn = new Button();
            friendBtn.Text = "Eliminar amigo";
            friendBtn.ForeColor = Color.White;
            friendBtn.BackColor = Color.FromArgb(1, 52, 107);
            friendBtn.Location = new Point(profileBtn.Location.X + profileBtn.Width + 50, profileBtn.Location.Y);
            friendBtn.FlatAppearance.BorderSize = 0;
            friendBtn.FlatStyle = FlatStyle.Flat;
            friendBtn.AutoSizeMode = AutoSizeMode.GrowOnly;
            friendBtn.AutoSize = true;
            friendBtn.Name = user.ID.ToString();
            friendBtn.Click += new EventHandler(friendBtnClick);

            temp.Controls.Add(pic);
            temp.Controls.Add(nameLbl);
            temp.Controls.Add(profileBtn);
            temp.Controls.Add(friendBtn);

            return temp;
        }

        public void profileBtnClick(object sender, EventArgs e)
        {
            _form.Hide();
            Form next = new OtherProfile(Convert.ToInt32((sender as Button).Name));
            next.ShowDialog();
            _form.Close();
        }

        public void friendBtnClick(object sender, EventArgs e)
        {
            User otherUser = _proxy.GetUserById(Convert.ToInt32((sender as Button).Name));
            if (MessageBox.Show($"¿Seguro que quieres eliminar a {otherUser.firstName}?", "Eliminar amigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                bool check = _proxy.DeleteFriendship(_userID, otherUser.ID);

                if (check)
                {
                    _form.Hide();
                    User temp = _proxy.GetUserById(_userID);
                    temp.friends = _proxy.GetFriends(temp.ID);
                    Form next = new FriendList(temp);
                    next.ShowDialog();
                    _form.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
