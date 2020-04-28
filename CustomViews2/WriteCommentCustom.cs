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
    public class WriteCommentCustom
    {
        private Form _form;
        private Panel _mainPanel;
        private Point _targetLocation;
        private int _postID;
        private int _userID;
        private ProxyFacebook _proxy;
        TextBox commentTxt;
        Action _refresh;

        public WriteCommentCustom(Action refresh, Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            this._mainPanel = panel;
            this._targetLocation = targetLocation;
            this._postID = postID;
            this._userID = userID;
            this._proxy = proxy;
            this._form = form;
            this._refresh = refresh;
        }

        public void AddResults()
        {
            int x = 0;
            int y = 0;

            Panel temp = this.CreateItem(x, y);
            _mainPanel.Controls.Add(temp);

        }

        private Panel CreateItem(int x, int y)
        {
            Panel temp = new Panel();
            temp.Location = new Point(_mainPanel.Location.X, _targetLocation.Y + 50);
            temp.BorderStyle = BorderStyle.None;
            temp.ClientSize = new Size(1315 / 2 - 60, 50);
            //temp.AutoSize = true;

            commentTxt = new TextBox();
            commentTxt.Text = "Escribir comentario...";
            commentTxt.ClientSize = new Size(500, 20);
            commentTxt.Multiline = true;
            commentTxt.ForeColor = SystemColors.InactiveCaption;
            commentTxt.BackColor = SystemColors.Window;
            commentTxt.TextChanged += new EventHandler(commentTxtChanged);

            Button sendBtn = new Button();
            sendBtn.Text = "Enviar";
            sendBtn.ForeColor = Color.White;
            sendBtn.BackColor = Color.FromArgb(1, 52, 107);
            sendBtn.Location = new Point(commentTxt.Location.X + commentTxt.Width + 10, commentTxt.Location.Y);
            sendBtn.AutoSize = true;
            sendBtn.FlatStyle = FlatStyle.Flat;
            sendBtn.FlatAppearance.BorderSize = 0;
            sendBtn.Click += new EventHandler(sendBtnClick);

            temp.Controls.Add(sendBtn);
            temp.Controls.Add(commentTxt);

            //CommentListCustom commentList = new CommentListCustom(_form, _mainPanel, new Point(_targetLocation.X, _targetLocation.Y + 50), _postID, _proxy);
            //commentList.AddResults();

            //this.CommentListCustom(new Point(_targetLocation.X, _targetLocation.Y + 50));

            return temp;
        }

        /*public void CommentListCustom(Point targetLocation)
        {
            Point _targetLocation = targetLocation;
            List<Comment> _results = _proxy.GetComments(_postID);
            int x = 0;
            int y = _targetLocation.Y + 50;

            foreach (Comment comment in _results)
            {
                var temp = this.CreateItem2(comment, x, y);
                _mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 5;
            }
        }

        private Panel CreateItem2(Comment com, int x, int y)
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
        }*/

        public void commentTxtChanged(object sender, EventArgs e)
        {
            (sender as TextBox).ForeColor = Color.Black;
        }

        public void sendBtnClick(object sender, EventArgs e)
        {
            if (commentTxt.ForeColor == Color.Black && commentTxt.Text != "") {
                bool res = _proxy.AddComment(_postID, _userID, commentTxt.Text);
                if (res)
                {
                    _refresh();

                } else
                {
                    MessageBox.Show("Error al agregar comentario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Escribir comentario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}