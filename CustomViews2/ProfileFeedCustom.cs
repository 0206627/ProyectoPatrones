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
    public class ProfileFeedCustom
    {
        private Form _form;
        private Panel _mainPanel;
        private int _userID;
        private ProxyFacebook _proxy;
        private List<Post> _results;

        public ProfileFeedCustom(Form form, Panel panel, int userID, ProxyFacebook proxy)
        {
            this._mainPanel = panel;
            this._userID = userID;
            this._proxy = proxy;
            this._form = form;
            _results = proxy.GetPostsById(_userID);
        }

        public void AddResults()
        {
            int x = 0;
            int y = 0;

            foreach (Post post in _results)
            {
                var temp = this.CreateItem(post, x, y);
                _mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 20;
            }

        }

        private Panel CreateItem(Post post, int x, int y)
        {
            User user = _proxy.GetUserById(post.userID);

            Panel temp = new Panel();
            temp.Location = new Point(x + 5, y);
            temp.BorderStyle = BorderStyle.None;
            //temp.ClientSize = new Size(1315 / 2 - 11, 644 / 4);
            temp.AutoSize = true;

            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(10, 10);
            pic.Size = new Size(60, 60);
            pic.BorderStyle = BorderStyle.None;
            pic.Image = Image.FromFile(user.profilePicture.ToString());

            Label nameLbl = new Label();
            nameLbl.Location = new Point(pic.Width + 15, pic.Location.Y);
            nameLbl.Font = new Font(nameLbl.Font.FontFamily, 10, FontStyle.Bold);
            nameLbl.AutoSize = true;
            nameLbl.Text = $"{user.firstName} {user.lastName}";

            Label dateLbl = new Label();
            dateLbl.Location = new Point(nameLbl.Location.X, nameLbl.Location.Y + 20);
            dateLbl.Font = new Font(dateLbl.Font.FontFamily, 7, FontStyle.Regular);
            dateLbl.AutoSize = true;
            dateLbl.Text = post.postDate.ToString();

            Label postLbl = new Label();
            postLbl.Location = new Point(pic.Location.X, pic.Location.Y + pic.Height + 15);
            postLbl.Font = new Font(postLbl.Font.FontFamily, 12, FontStyle.Regular);
            postLbl.AutoSize = true;
            postLbl.Text = post.postTxt;
            postLbl.BorderStyle = BorderStyle.None;

            if (post.postImage != "null")
            {
                PictureBox postPic = new PictureBox();
                postPic.SizeMode = PictureBoxSizeMode.Zoom;
                postPic.Location = new Point(nameLbl.Location.X + 400, nameLbl.Location.Y + nameLbl.Height);
                postPic.Size = new Size(150, 100);
                postPic.BorderStyle = BorderStyle.None;
                postPic.Image = Image.FromFile(post.postImage);
                temp.Controls.Add(postPic);
            }

            LikeCustom like = new LikeCustom(_form, temp, new Point(postLbl.Location.X, postLbl.Location.Y + postLbl.Height), post.ID, _userID, _proxy);
            like.AddResults();

            //WriteCommentCustom comment = new WriteCommentCustom(_form, temp, new Point(postLbl.Location.X, postLbl.Location.Y + postLbl.Height), post.ID, _userID, _proxy);
            //comment.AddResults();

            /*CommentListCustom commentList = new CommentListCustom(_form, temp, new Point(postLbl.Location.X, postLbl.Location.Y + postLbl.Height + 50), post.ID, _proxy);
            commentList.AddResults();*/

            temp.Controls.Add(pic);
            temp.Controls.Add(nameLbl);
            temp.Controls.Add(dateLbl);
            temp.Controls.Add(postLbl);

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
            }
            else
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
