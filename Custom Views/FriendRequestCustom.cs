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
    public class FriendRequestCustom
    {
        private Form _form;
        private Panel _mainPanel;
        private int _userID;
        private ProxyFacebook _proxy;
        private List<User> _results;

        public FriendRequestCustom(Form form, Panel panel, int userID, List<User> results, ProxyFacebook proxy)
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

            if (!(_results.Count > 0))
            {
                Label notLabel = new Label();
                notLabel.Location = new Point(x, y);
                notLabel.AutoSize = true;
                notLabel.Text = "Sin solicitudes de amistad.";
                notLabel.Font = new Font(notLabel.Font.FontFamily, 15, FontStyle.Regular);
                _mainPanel.Controls.Add(notLabel);
            }
            else
            {

                foreach (User user in _results)
                {
                    var temp = this.CreateItem(user, x, y);
                    _mainPanel.Controls.Add(temp);
                    y += temp.Size.Height + 30;
                }
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
            profileBtn.Location = new Point(pic.Width + 15 + 230, pic.Location.Y + 50);
            profileBtn.FlatAppearance.BorderSize = 0;
            profileBtn.FlatStyle = FlatStyle.Flat;
            profileBtn.Name = user.ID.ToString();
            profileBtn.Click += new EventHandler(profileBtnClick);

            Button acceptBtn = new Button();
            acceptBtn.Text = "Aceptar";
            acceptBtn.ForeColor = Color.White;
            acceptBtn.BackColor = Color.FromArgb(1, 52, 107);
            acceptBtn.Location = new Point(profileBtn.Location.X + profileBtn.Width + 50, profileBtn.Location.Y);
            acceptBtn.FlatAppearance.BorderSize = 0;
            acceptBtn.FlatStyle = FlatStyle.Flat;
            acceptBtn.Name = user.ID.ToString();
            acceptBtn.Click += new EventHandler(acceptBtnClick);

            Button rejectBtn = new Button();
            rejectBtn.Text = "Rechazar";
            rejectBtn.ForeColor = Color.White;
            rejectBtn.BackColor = Color.FromArgb(1, 52, 107);
            rejectBtn.Location = new Point(acceptBtn.Location.X + profileBtn.Width + 50, acceptBtn.Location.Y);
            rejectBtn.FlatAppearance.BorderSize = 0;
            rejectBtn.FlatStyle = FlatStyle.Flat;
            rejectBtn.AutoSizeMode = AutoSizeMode.GrowOnly;
            rejectBtn.AutoSize = true;
            rejectBtn.Name = user.ID.ToString();
            rejectBtn.Click += new EventHandler(rejectBtnClick);

            temp.Controls.Add(pic);
            temp.Controls.Add(nameLbl);
            temp.Controls.Add(profileBtn);
            temp.Controls.Add(acceptBtn);
            temp.Controls.Add(rejectBtn);

            return temp;
        }

        public void profileBtnClick(object sender, EventArgs e)
        {
            _form.Hide();
            Form next = new OtherProfile(Convert.ToInt32((sender as Button).Name));
            next.ShowDialog();
            _form.Close();
        }

        public void acceptBtnClick(object sender, EventArgs e)
        {
            bool check = _proxy.CreateFriendship(_userID, Convert.ToInt32((sender as Button).Name));

            if (check)
            {
                _form.Hide();
                Form next = new OtherProfile(Convert.ToInt32((sender as Button).Name));
                next.ShowDialog();
                _form.Close();
            } else
            {
                MessageBox.Show("Error al agregar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void rejectBtnClick(object sender, EventArgs e)
        {
            bool check = _proxy.DeleteFriendshipRequest(_userID, Convert.ToInt32((sender as Button).Name));

            if (check)
            {
                _form.Hide();
                Form next = new FriendRequest();
                next.ShowDialog();
                _form.Close();
            }
            else
            {
                MessageBox.Show("Error al rechazar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
