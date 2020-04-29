using MiniFacebookVisual.Patrones.BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Builder
{
    public abstract class LikeCommentBuilder
    {
        public LikeComment likeComment;

        public LikeComment ObtenerLikeComment
        {
            get { return this.likeComment; }
        }

        public abstract void AddResults();
        public abstract Panel CreateItem(int x, int y);
    }
}
