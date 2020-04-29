using Core_API.Models;
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
    public class BuilderLikeList : LikeCommentBuilder
    {
        public BuilderLikeList(Action refresh, Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            likeComment = new LikeComment(refresh, form, panel, targetLocation, postID, userID, proxy);
            likeComment.likes = proxy.GetLikes(postID);
        }

        public override void AddResults()
        {
            int x = 0;
            int y = likeComment.targetLocation.Y + 5;

            foreach (User user in likeComment.likes)
            {
                var temp = this.CreateItem(user, x, y);
                likeComment.mainPanel.Controls.Add(temp);
                y += temp.Size.Height;
            }

        }

        public override Panel CreateItem(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Panel CreateItem(User user, int x, int y)
        {

            Panel temp = new Panel();
            temp.Location = new Point(x, y);
            temp.BorderStyle = BorderStyle.None;
            temp.Size = new Size(400, 50);

            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Location = new Point(0,0);
            pic.Size = new Size(40, 40);
            pic.BorderStyle = BorderStyle.None;
            pic.Image = Image.FromFile(user.profilePicture.ToString());

            Label nameLbl = new Label();
            nameLbl.Location = new Point(pic.Width + 15, pic.Location.Y + 10);
            nameLbl.Font = new Font(nameLbl.Font.FontFamily, 11, FontStyle.Regular);
            nameLbl.AutoSize = true;
            nameLbl.Text = $"{user.firstName} {user.lastName}";

            temp.Controls.Add(pic);
            temp.Controls.Add(nameLbl);
            pic.BringToFront();
            nameLbl.BringToFront();

            return temp;
        }
    }
}
