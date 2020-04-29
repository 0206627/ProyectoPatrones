using MiniFacebookVisual.Patrones.BuilderPattern.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Director;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Views
{
    public partial class LikeList : Form
    {
        public int postID;
        public LikeList(int postID)
        {
            this.postID = postID;
            InitializeComponent();
            var likeCommentCooker = new LikeCommentCooker(new BuilderLikeList(aux, this, postPanel, new Point(0,0), this.postID, this.postID, MainView.proxy));
            likeCommentCooker.ObtenerLikeComment();
        }

        public void aux() { }
    }
}
