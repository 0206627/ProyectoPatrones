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
    public class FeedCustom
    {
        private Form _form;
        private Panel _mainPanel;
        private int _userID;
        private int _otherUserID;
        private ProxyFacebook _proxy;
        private List<Post> _results;
        private Action _refresh;

        public FeedCustom(Action refresh, string mode, Form form, Panel panel, int userID, int otherUserID, ProxyFacebook proxy)
        {
            this._mainPanel = panel;
            this._userID = userID;
            this._proxy = proxy;
            this._form = form;
            this._refresh = refresh;
            this._otherUserID = otherUserID;
            if (mode == "Feed") _results = proxy.GetPosts(_userID);
            else _results = proxy.GetPostsById(_otherUserID);
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
            temp.Location = new Point(x+5, y);
            temp.BorderStyle = BorderStyle.None;
            //temp.ClientSize = new Size(1315/2 - 11, 644/4);
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

            List<string> taggedPeople = _proxy.GetTags(post.ID);

            Label taggedLbl = new Label();
            taggedLbl.Location = new Point(postLbl.Location.X, postLbl.Location.Y + postLbl.Height + 15);
            taggedLbl.Font = new Font(taggedLbl.Font.FontFamily, 8, FontStyle.Bold);
            taggedLbl.AutoSize = true;
            taggedLbl.Text = "Con ";
            taggedLbl.BorderStyle = BorderStyle.None;

            Label peopleLbl = new Label();
            peopleLbl.Location = new Point(taggedLbl.Location.X + 35, taggedLbl.Location.Y);
            peopleLbl.Font = new Font(peopleLbl.Font.FontFamily, 8, FontStyle.Regular);
            peopleLbl.AutoSize = true;
            peopleLbl.BorderStyle = BorderStyle.None;

            if (taggedPeople.Count > 0)
            {

                peopleLbl.Text = "";

                foreach(var person in taggedPeople)
                {
                    peopleLbl.Text += $"{person}, ";
                }

                peopleLbl.Text = peopleLbl.Text.Remove(peopleLbl.Text.Length - 2);

                temp.Controls.Add(taggedLbl);
                temp.Controls.Add(peopleLbl);

            }

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

            LikeCustom like = new LikeCustom(_form, temp, new Point(taggedLbl.Location.X, taggedLbl.Location.Y + taggedLbl.Height), post.ID, _userID, _proxy);
            like.AddResults();

            WriteCommentCustom comment = new WriteCommentCustom(_refresh,_form, temp, new Point(taggedLbl.Location.X, taggedLbl.Location.Y + taggedLbl.Height), post.ID, _userID, _proxy);
            comment.AddResults();

            CommentListCustom commentList = new CommentListCustom(_form, temp, new Point(taggedLbl.Location.X, taggedLbl.Location.Y + taggedLbl.Height + 50), post.ID, _proxy);
            commentList.AddResults();

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