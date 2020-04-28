using MiniFacebookVisual.Patrones.Builder;
using MiniFacebookVisual.Patrones.BuilderPattern.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Director
{
    public class FeedCooker
    {
        private FeedBuilder _feedBuilder;
        public FeedCooker(FeedBuilder feedBuilder)
        {
            _feedBuilder = feedBuilder;
        }

        public Feed ObtenerFeed()
        {
            _feedBuilder.AddResults();
            return _feedBuilder.ObtenerFeed;
        }
    }
}
