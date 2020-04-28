using Core_API.Models;
using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.BuilderPattern.Models
{
    public class LikeComment
    {

        public Form form;
        public Panel mainPanel;
        public Point targetLocation;
        public int postID;
        public int userID;
        public ProxyFacebook proxy;
        public Action refresh;
        public List<Comment> results;

        public LikeComment(Action refresh, Form form, Panel panel, Point targetLocation, int postID, int userID, ProxyFacebook proxy)
        {
            mainPanel = panel;
            this.targetLocation = targetLocation;
            this.userID = userID;
            this.postID = postID;
            this.proxy = proxy;
            this.form = form;
            this.refresh = refresh;
        }

    }
}
