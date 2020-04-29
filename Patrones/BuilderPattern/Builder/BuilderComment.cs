using Core.Models;
using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Builder
{
    public class BuilderComment : LikeCommentBuilder
    {
        public BuilderComment(Action refresh, Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            likeComment = new LikeComment(refresh, form, panel, targetLocation, postID, userID, proxy);
            likeComment.results = proxy.GetComments(likeComment.postID);
        }

        public override void AddResults()
        {
            int x = 0;
            int y = likeComment.targetLocation.Y + 50;

            foreach (Comment comment in likeComment.results)
            {
                var temp = this.CreateItem(comment, x, y);
                likeComment.mainPanel.Controls.Add(temp);
                y += temp.Size.Height + 5;
            }

        }

        public override Panel CreateItem(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Panel CreateItem(Comment com, int x, int y)
        {
            User user = likeComment.proxy.GetUserById(com.userID);

            Panel temp = new Panel();
            temp.Location = new Point(x, y);
            temp.BorderStyle = BorderStyle.None;

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
