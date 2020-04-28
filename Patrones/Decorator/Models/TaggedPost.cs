using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Patrones.Decorator.Models
{
    public class TaggedPost : ITaggedPost
    {

        public TaggedPost(int postID, ProxyFacebook proxy)
        {
            _postID = postID;
            _tags = new List<int>();
            this.proxy = proxy;
        }
        public override int ObtenerID()
        {
            return _postID;
        }

        public override List<int> ObtenerTags()
        {
            return _tags;
        }
    }
}
