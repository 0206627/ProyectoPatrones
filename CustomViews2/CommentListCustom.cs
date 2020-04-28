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
    public class CommentListCustom
    {
        private Form _form;
        private Panel _mainPanel;
        private int _postID;
        private ProxyFacebook _proxy;
        private List<Comment> _results;
        private Point _targetLocation;

        public CommentListCustom(Form form, Panel panel, Point targetLocation, int postID, ProxyFacebook proxy)
        {
            this._mainPanel = panel;
            this._postID = postID;
            this._proxy = proxy;
            this._form = form;
            this._targetLocation = targetLocation;
            _results = proxy.GetComments(_postID);
        }

        public void AddResults()
        {
            int x = 0;
            int y = _targetLocation.Y + 50;

            foreach (Comment comment in _results)
            {
                var temp = this.CreateItem(comment, x, y);
                _mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 5;
            }

        }

        private Panel CreateItem(Comment com, int x, int y)
        {
            User user = _proxy.GetUserById(com.userID);

            Panel temp = new Panel();
            temp.Location = new Point(x, y);
            temp.BorderStyle = BorderStyle.None;
            //temp.ClientSize = new Size(1315/2 - 11, 644/4);
            //temp.AutoSize = true;

            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(10, 10);
            pic.Size = new Size(25, 25);
            pic.BorderStyle = BorderStyle.None;
            pic.Image = Image.FromFile(user.profilePicture.ToString());

            Label nameLbl = new Label();
            nameLbl.Location = new Point(pic.Width + 15, pic.Location.Y + 2);
            nameLbl.Font = new Font(nameLbl.Font.FontFamily, 9, FontStyle.Bold);
            nameLbl.AutoSize = true;
            nameLbl.Text = $"{user.firstName} {user.lastName}";

            Label commentLbl = new Label();
            commentLbl.Location = new Point(nameLbl.Location.X + nameLbl.Width + 40, nameLbl.Location.Y);
            commentLbl.Font = new Font(commentLbl.Font.FontFamily, 9, FontStyle.Regular);
            commentLbl.AutoSize = true;
            commentLbl.Text = com.comment;
            commentLbl.BorderStyle = BorderStyle.None;

            temp.ClientSize = new Size(600, 50);

            temp.Controls.Add(pic);
            temp.Controls.Add(nameLbl);
            temp.Controls.Add(commentLbl);

            return temp;
        }
    }
}