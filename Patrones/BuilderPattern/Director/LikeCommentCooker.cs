using MiniFacebookVisual.Patrones.BuilderPattern.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Director
{
    public class LikeCommentCooker
    {
        private LikeCommentBuilder _likeCommentBuilder;
        public LikeCommentCooker(LikeCommentBuilder likeCommentBuilder)
        {
            _likeCommentBuilder = likeCommentBuilder;
        }

        public LikeComment ObtenerLikeComment()
        {
            _likeCommentBuilder.AddResults();
            return _likeCommentBuilder.ObtenerLikeComment;
        }
    }
}
