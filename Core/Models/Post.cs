using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string postTxt { get; set; }
        public string postImage { get; set; }
        public DateTime postDate { get; set; }

        public Post() { }

        public Post(int ID, int userID, string postTxt, string postImage, DateTime postDate)
        {
            this.ID = ID;
            this.userID = userID;
            this.postTxt = postTxt;
            this.postImage = postImage;
            this.postDate = postDate;
        }

    }

}