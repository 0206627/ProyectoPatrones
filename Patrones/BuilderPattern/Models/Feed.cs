using Core_API.Models;

using MiniFacebookVisual.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFacebookVisual.Patrones.Builder
{
    public class Feed
    {
        public Form form;
        public Panel mainPanel;
        public int userID;
        public int otherUserID;
        public ProxyFacebook proxy;
        public List<Post> results;
        public Action refresh;

        public Feed(Action refresh, Form form, Panel panel, int userID, int otherUserID, ProxyFacebook proxy)
        {
            this.mainPanel = panel;
            this.userID = userID;
            this.proxy = proxy;
            this.form = form;
            this.refresh = refresh;
            this.otherUserID = otherUserID;
        }
    }
}

