using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Patrones.Decorator.Models
{
    public class TagDecorador : ITaggedPost
    {
        private ITaggedPost _taggedPost;

        public TagDecorador(ITaggedPost taggedPost, int id)
        {
            _taggedPost = taggedPost;
            _tags = _taggedPost.ObtenerTags();
            _postID = _taggedPost._postID;
            proxy = _taggedPost.proxy;
            _tags.Add(id);
            proxy.AddPostToTag(id, _postID);
        }

        public override List<int> ObtenerTags()
        {
            return _tags;
        }

        public override int ObtenerID()
        {
            return _taggedPost.ObtenerID();
        }
    }
}
