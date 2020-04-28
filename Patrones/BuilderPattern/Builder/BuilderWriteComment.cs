using Core_API.Models;
using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.Builder;
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
    public class BuilderWriteComment : LikeCommentBuilder
    {
        TextBox commentTxt;
        public BuilderWriteComment(Action refresh, Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            likeComment = new LikeComment(refresh, form, panel, targetLocation, postID, userID, proxy);
        }

        public override void AddResults()
        {
            int x = 0;
            int y = 0;

            Panel temp = this.CreateItem(x, y);
            likeComment.mainPanel.Controls.Add(temp);

        }

        public override Panel CreateItem(int x, int y)
        {
            Panel temp = new Panel();
            temp.Location = new Point(likeComment.mainPanel.Location.X, likeComment.targetLocation.Y + 50);
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

            return temp;
        }

        public void commentTxtChanged(object sender, EventArgs e)
        {
            (sender as TextBox).ForeColor = Color.Black;
        }

        public void sendBtnClick(object sender, EventArgs e)
        {
            if (commentTxt.ForeColor == Color.Black && commentTxt.Text != "")
            {
                bool res = likeComment.proxy.AddComment(likeComment.postID, likeComment.userID, commentTxt.Text);
                if (res)
                {
                    likeComment.refresh();

                }
                else
                {
                    MessageBox.Show("Error al agregar comentario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Escribir comentario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
