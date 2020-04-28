using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Patrones.Decorator.Models
{
    public abstract class ITaggedPost
    {
        public List<int> _tags;
        public int _postID;
        public ProxyFacebook proxy;
        public abstract List<int> ObtenerTags();
        public abstract int ObtenerID();
    }
}
