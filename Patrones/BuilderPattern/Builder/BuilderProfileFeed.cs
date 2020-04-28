using Core_API.Models;

using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Director;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Builder
{
    public class BuilderProfileFeed : FeedBuilder
    {
        public BuilderProfileFeed(Action refresh, Form form, Panel panel, int userID, int otherUserID, ProxyFacebook proxy)
        {
            feed = new Feed(refresh, form, panel, userID, otherUserID, proxy);
            feed.results = proxy.GetPostsById(otherUserID);
        }

        public override void AddResults()
        {
            int x = 0;
            int y = 0;

            foreach (Post post in feed.results)
            {
                var temp = this.CreateItem(post, x, y);
                feed.mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 20;
            }
        }

        public override Panel CreateItem(Post post, int x, int y)
        {
            User user = feed.proxy.GetUserById(post.userID);

            Panel temp = new Panel();
            temp.Location = new Point(x + 5, y);
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

            List<string> taggedPeople = feed.proxy.GetTags(post.ID);

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

                foreach (var person in taggedPeople)
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

            var likeCommentCooker = new LikeCommentCooker(new BuilderLike(feed.refresh, feed.form, temp, new Point(taggedLbl.Location.X, taggedLbl.Location.Y + taggedLbl.Height), post.ID, feed.userID, feed.proxy));
            likeCommentCooker.ObtenerLikeComment();

            likeCommentCooker = new LikeCommentCooker(new BuilderWriteComment(feed.refresh, feed.form, temp, new Point(taggedLbl.Location.X, taggedLbl.Location.Y + taggedLbl.Height), post.ID, feed.userID, feed.proxy));
            likeCommentCooker.ObtenerLikeComment();

            likeCommentCooker = new LikeCommentCooker(new BuilderComment(feed.refresh, feed.form, temp, new Point(taggedLbl.Location.X, taggedLbl.Location.Y + taggedLbl.Height + 50), post.ID, feed.userID, feed.proxy));
            likeCommentCooker.ObtenerLikeComment();

            temp.Controls.Add(pic);
            temp.Controls.Add(nameLbl);
            temp.Controls.Add(dateLbl);
            temp.Controls.Add(postLbl);

            return temp;
        }

        public void profileBtnClick(object sender, EventArgs e)
        {
            feed.form.Hide();
            Form next = new OtherProfile(Convert.ToInt32((sender as Button).Name));
            next.ShowDialog();
            feed.form.Close();
        }

        public void acceptBtnClick(object sender, EventArgs e)
        {
            bool check = feed.proxy.CreateFriendship(feed.userID, Convert.ToInt32((sender as Button).Name));

            if (check)
            {
                feed.form.Hide();
                Form next = new OtherProfile(Convert.ToInt32((sender as Button).Name));
                next.ShowDialog();
                feed.form.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void rejectBtnClick(object sender, EventArgs e)
        {
            bool check = feed.proxy.DeleteFriendshipRequest(feed.userID, Convert.ToInt32((sender as Button).Name));

            if (check)
            {
                feed.form.Hide();
                Form next = new FriendRequest();
                next.ShowDialog();
                feed.form.Close();
            }
            else
            {
                MessageBox.Show("Error al rechazar amigo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
