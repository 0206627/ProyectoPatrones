using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Builder
{
    public class BuilderLike : LikeCommentBuilder
    {
        Label likesCountLbl;
        public BuilderLike(Action refresh, Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            likeComment = new LikeComment(refresh, form, panel, targetLocation, postID, userID, proxy);
        }

        public override void AddResults()
        {
            int x = 0;
            int y = 0;

            var temp = this.CreateItem(x, y);
            likeComment.mainPanel.Controls.Add(temp);

        }

        public override Panel CreateItem(int x, int y)
        {
            Panel temp = new Panel();
            temp.Location = new Point(likeComment.mainPanel.Location.X, likeComment.targetLocation.Y + 10);
            temp.BorderStyle = BorderStyle.None;
            temp.ClientSize = new Size(1315 / 2 - 60, 25);
            //temp.AutoSize = true;

            Button likeBtn = new Button();
            likeBtn.BackgroundImageLayout = ImageLayout.Zoom;
            likeBtn.FlatAppearance.BorderSize = 0;
            bool isLiked = likeComment.proxy.IsLiked(likeComment.postID, likeComment.userID);
            if (isLiked)
            {
                likeBtn.BackgroundImage = Image.FromFile("C:\\Users\\Mariana De la Vega\\Desktop\\Patrones\\MiniFacebookVisual\\images\\likeIcon2.png");
                likeBtn.BackColor = Color.FromArgb(1, 52, 107);
            }
            else
            {
                likeBtn.BackgroundImage = Image.FromFile("C:\\Users\\Mariana De la Vega\\Desktop\\Patrones\\MiniFacebookVisual\\images\\likeIcon2Blue.png");
                likeBtn.BackColor = Color.Transparent;
            }
            likeBtn.Size = new Size(40, 25);
            likeBtn.FlatStyle = FlatStyle.Flat;
            likeBtn.Click += new EventHandler(likeBtnClick);

            likesCountLbl = new Label();
            this.changeLikeLbl();
            likesCountLbl.Location = new Point(likeBtn.Location.X + likeBtn.Width + 10, likeBtn.Location.Y + 5);
            likesCountLbl.AutoSize = true;

            temp.Controls.Add(likeBtn);
            temp.Controls.Add(likesCountLbl);

            return temp;
        }

        public void likeBtnClick(object sender, EventArgs e)
        {
            bool res;

            if ((sender as Button).BackColor == Color.FromArgb(1, 52, 107)) res = likeComment.proxy.DislikePost(likeComment.postID, likeComment.userID);
            else res = likeComment.proxy.LikePost(likeComment.postID, likeComment.userID);

            if (res)
            {
                this.changeLikeBtn((sender as Button));
                this.changeLikeLbl();
            }
            else
            {
                MessageBox.Show("Error relacionado al like.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeLikeBtn(Button likeBtn)
        {
            if (likeBtn.BackColor == Color.Transparent)
            {
                likeBtn.BackgroundImage = Image.FromFile("C:\\Users\\Mariana De la Vega\\Desktop\\Patrones\\MiniFacebookVisual\\images\\likeIcon2.png");
                likeBtn.BackColor = Color.FromArgb(1, 52, 107);
            }
            else
            {
                likeBtn.BackgroundImage = Image.FromFile("C:\\Users\\Mariana De la Vega\\Desktop\\Patrones\\MiniFacebookVisual\\images\\likeIcon2Blue.png");
                likeBtn.BackColor = Color.Transparent;
            }
        }

        private void changeLikeLbl()
        {
            int likes = likeComment.proxy.LikesCount(likeComment.postID);
            if (likes != 1) likesCountLbl.Text = likes.ToString() + " likes";
            else likesCountLbl.Text = likes.ToString() + " like";
        }

    }
}
