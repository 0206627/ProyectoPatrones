using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Comment
    {
        public int postID { get; set; }
        public int userID { get; set; }
        public string comment { get; set; }

        public Comment() { }

        public Comment(int postID, int userID, string comment)
        {
            this.postID = postID;
            this.userID = userID;
            this.comment = comment;
        }

    }
}
