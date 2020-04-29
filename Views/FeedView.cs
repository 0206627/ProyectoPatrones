using Core_API.Models;

using MiniFacebookVisual.Models;
using MiniFacebookVisual.Patrones.BuilderPattern.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Director;
using MiniFacebookVisual.Patrones.Decorator.Models;
using MiniFacebookVisual.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual
{
    public partial class FeedView : Form
    {
        string imageLocation;
        User user;
        ProxyFacebook proxy;

        public FeedView()
        {
            user = MainView.user;
            proxy = MainView.proxy;
            user = proxy.GetUserById(user.ID);
            InitializeComponent();
            var feedCooker = new FeedCooker(new BuilderMainFeed(this.refresh, this, postPanel, user.ID, user.ID, proxy));
            feedCooker.ObtenerFeed();
            if (postPanel.Controls.Count < 2)
            {
                noPostLbl.Text = "Sin actividad en tu feed.";
            } 
            nameBtn.Text = user.firstName;
            imageLocation = "null";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void nameBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new Profile();
            next.ShowDialog();
            this.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text != "")
            {
                this.Hide();
                Form next = new FriendSearch(searchTxt.Text);
                next.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Rellenar búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new MainView();
            next.ShowDialog();
            this.Close();
        }

        private void friendBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FriendRequest();
            next.ShowDialog();
            this.Close();
        }

        private void feedBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new FeedView();
            next.ShowDialog();
            this.Close();
        }

        private void addImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    postImage.Image = Image.FromFile(imageLocation);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendPostBtn_Click(object sender, EventArgs e)
        {
            if (sharePostTxt.Text != "" && sharePostTxt.ForeColor == Color.Black)
            {
                
                List<int> tagID = TagFriends.tagID;
                int postID = proxy.AddPost(user.ID, sharePostTxt.Text, imageLocation);

                if (postID != 0) {

                    if (tagID.Count > 0)
                    {
                        ITaggedPost taggedPost = new TagDecorador(new TaggedPost(postID, proxy), tagID[0]);

                        if (tagID.Count > 1)
                        {
                            for (int i = 1; i < tagID.Count; i++)
                            {
                                taggedPost = new TagDecorador(taggedPost, tagID[i]);
                            }
                        }

                        List<int> tags = taggedPost.ObtenerTags();

                    }

                    TagFriends.tagID.Clear();
                    TagFriends.tagged.Clear();
                    refresh();

                } else
                {
                    MessageBox.Show("Ocurrió un error al publicar el post.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Escribir en el post.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sharePostTxt_TextChanged(object sender, EventArgs e)
        {
            sharePostTxt.ForeColor = Color.Black;
        }

        private void addTagBtn_Click(object sender, EventArgs e)
        {
            Form next = new TagFriends();
            next.ShowDialog();

            bool res = false;

            while (true)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "TagFriends") res = true;
                }

                if (!res) break;
            }

            refreshTaggedLbl();
        }

        private void refreshTaggedLbl()
        {
            taggedLbl.Text = "";

            foreach(var friend in TagFriends.tagged)
            {
                taggedLbl.Text += $"{friend}, ";
            }

            if (taggedLbl.Text.Length > 0) taggedLbl.Text = taggedLbl.Text.Remove(taggedLbl.Text.Length - 2);
        }

        public void refresh()
        {
            noPostLbl.Text = "";
            refreshPost();
            int scroll = postPanel.VerticalScroll.Value;
            postPanel.Controls.Clear();
            var feedCooker = new FeedCooker(new BuilderMainFeed(this.refresh, this, postPanel, user.ID, user.ID, proxy));
            feedCooker.ObtenerFeed();
            postPanel.VerticalScroll.Value = scroll;
        }

        public void refreshPost()
        {
            taggedLbl.Text = "";
            sharePostTxt.Text = "¿Qué estás pensando?";
            sharePostTxt.ForeColor = SystemColors.InactiveCaption;
        }

        private void bannerImage_Click(object sender, EventArgs e)
        {

        }

        private void FeedView_Load(object sender, EventArgs e)
        {

        }
    }
}
