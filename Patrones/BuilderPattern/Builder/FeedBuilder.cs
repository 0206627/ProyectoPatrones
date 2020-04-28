using Core_API.Models;
using MiniFacebookVisual.Patrones.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Builder
{
    public abstract class FeedBuilder
    {
        public Feed feed;

        public Feed ObtenerFeed
        {
            get { return this.feed; }
        }

        public abstract void AddResults();
        public abstract Panel CreateItem(Post post, int x, int y);
        
    }
}
