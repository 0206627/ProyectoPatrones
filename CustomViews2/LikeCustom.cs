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
    public class LikeCustom
    {
        private Form _form;
        private Panel _mainPanel;
        private Point _targetLocation;
        private int _postID;
        private int _userID;
        private ProxyFacebook _proxy;
        Label likesCountLbl;

        public LikeCustom(Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            this._mainPanel = panel;
            this._targetLocation = targetLocation;
            this._postID = postID;
            this._userID = userID;
            this._proxy = proxy;
            this._form = form;
        }

        public void AddResults()
        {
            int x = 0;
            int y = 0;

            var temp = this.CreateItem(x, y);
            _mainPanel.Controls.Add(temp);

        }

        private Panel CreateItem(int x, int y)
        {

            Panel temp = new Panel();
            temp.Location = new Point(_mainPanel.Location.X, _targetLocation.Y + 10);
            temp.BorderStyle = BorderStyle.None;
            temp.ClientSize = new Size(1315 / 2 - 60, 25);
            //temp.AutoSize = true;

            Button likeBtn = new Button();
            likeBtn.BackgroundImageLayout = ImageLayout.Zoom;
            likeBtn.FlatAppearance.BorderSize = 0;
            bool isLiked = _proxy.IsLiked(_postID, _userID);
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

            if ((sender as Button).BackColor == Color.FromArgb(1, 52, 107)) res = _proxy.DislikePost(_postID, _userID);
            else res = _proxy.LikePost(_postID, _userID);

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
            int likes = _proxy.LikesCount(_postID);
            if (likes != 1) likesCountLbl.Text = likes.ToString() + " likes";
            else likesCountLbl.Text = likes.ToString() + " like";
        }
    }
}