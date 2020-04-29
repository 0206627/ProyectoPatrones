using Core.Models;
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
    public class FriendSearchResult
    {
        private Form _form;
        private Panel _mainPanel;
        private int _userID;
        private ProxyFacebook _proxy;
        private List<User> _results;
        private string _checkMark = "✓";
        private string _crossMark = "✗";
        private string _pattern;

        public FriendSearchResult(Form form, Panel panel, int userID, List<User> results, ProxyFacebook proxy, string pattern)
        {
            this._mainPanel = panel;
            this._userID = userID;
            this._results = results;
            this._proxy = proxy;
            this._form = form;
            this._pattern = pattern;
        }

        public void AddResults()
        {
            int x = 25;
            int y = 20;

            foreach(User user in _results)
            {
                var temp = this.CreateItem(user, x, y);
                _mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 30;
            }
            
        }

        private Panel CreateItem(User user, int x, int y)
        {
            Panel temp = new Panel();
            temp.Location = new Point(x,y);
            temp.BorderStyle = BorderStyle.None;
            temp.ClientSize = new Size(1365/2, 187/2-10);

            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(5,0);
            pic.Size = new Size(100, temp.Height);
            pic.BorderStyle = BorderStyle.None;
            pic.Image = Image.FromFile(user.profilePicture.ToString());

            Label nameLbl = new Label();
            nameLbl.Location = new Point(pic.Width + 15, pic.Location.Y);
            nameLbl.Font = new Font(nameLbl.Font.FontFamily, 12, FontStyle.Bold);
            nameLbl.AutoSize = true;
            nameLbl.Text = $"{user.firstName} {user.lastName}";

            Label fixedLbl = new Label();
            fixedLbl.Location = new Point(pic.Width + 15, pic.Location.Y + 50);
            fixedLbl.Font = new Font(fixedLbl.Font.FontFamily, 10);
            fixedLbl.Text = "Amigos ";
            bool checkFriendship = _proxy.CheckFriendship(this._userID, user.ID);
            bool checkInversedRequest = _proxy.CheckRequest(user.ID, this._userID);

            if (checkFriendship) fixedLbl.Text += this._checkMark;
            else fixedLbl.Text += this._crossMark;

            Button profileBtn = new Button();
            profileBtn.Text = "Ver perfil";
            profileBtn.ForeColor = Color.White;
            profileBtn.BackColor = Color.FromArgb(1, 52, 107);
            profileBtn.Location = new Point(fixedLbl.Location.X + 300, fixedLbl.Location.Y);
            profileBtn.FlatAppearance.BorderSize = 0;
            profileBtn.FlatStyle = FlatStyle.Flat;
            profileBtn.Name = user.ID.ToString();
            profileBtn.Click += new EventHandler(profileBtnClick);

            Button friendBtn = new Button();
            if (checkInversedRequest) friendBtn.Text = "Cancelar solicitud";
            else if (checkFriendship) friendBtn.Text = "Eliminar amigo";
            else friendBtn.Text = "Añadir amigo";
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
            temp.Controls.Add(fixedLbl);
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
            if ((sender as Button).Text == "Añadir amigo")
            {
                bool check = _proxy.CreateFriendRequest(Convert.ToInt32((sender as Button).Name), _userID);

                if (check)
                {
                    _form.Hide();
                    Form next = new OtherProfile(Convert.ToInt32((sender as Button).Name));
                    next.ShowDialog();
                    _form.Close();
                }
                else
                {
                    MessageBox.Show("Error al mandar solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if ((sender as Button).Text == "Eliminar amigo")
            {
                User otherUser = _proxy.GetUserById(Convert.ToInt32((sender as Button).Name));
                if (MessageBox.Show($"¿Seguro que quieres eliminar a {otherUser.firstName}?", "Eliminar amigo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    bool check = _proxy.DeleteFriendship(_userID, otherUser.ID);

                    if (check)
                    {
                        _form.Hide();
                        Form next = new OtherProfile(otherUser.ID);
                        next.ShowDialog();
                        _form.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else
            {
                User otherUser = _proxy.GetUserById(Convert.ToInt32((sender as Button).Name));
                if (MessageBox.Show($"¿Seguro que quieres cancelar la solicitud de amistad a {otherUser.firstName}?", "Cancelar solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool check = _proxy.DeleteFriendshipRequest(otherUser.ID, _userID);

                    if (check)
                    {
                        _form.Hide();
                        Form next = new FriendSearch(_pattern);
                        next.ShowDialog();
                        _form.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar solicitud.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
