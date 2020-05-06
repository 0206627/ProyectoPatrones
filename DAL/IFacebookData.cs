using Core.Models;
using MiniFacebookVisual;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public abstract class IFacebookData
    {
        protected string connectionString;
        protected DataSet dataset;
        protected SqlConnection mySqlConnection;

        private SqlConnection getMySqlConnection()
        {
            if (mySqlConnection == null)
            {
                mySqlConnection = new SqlConnection(connectionString);
            }

            return mySqlConnection;
        }

        public IFacebookData()
        {
            this.connectionString = Configuration.connectionString;
        }

        public virtual bool Conectar()
        {
            mySqlConnection = getMySqlConnection();
            mySqlConnection.Open();
            return mySqlConnection.State == ConnectionState.Open;
        }

        public virtual void Desconectar()
        {
            connectionString = "";
            if (mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
        }

        public abstract int LogIn(string email, string pwd);
        public abstract int Register(string firstName, string lastName, string email, string pwd, string gender, DateTime birthday);
        public abstract User GetUserById(int id);
        public abstract bool DeleteUserById(int id);
        public abstract bool CheckExistingUser(string email);
        public abstract bool AddProfilePicture(string imageLocation, int id);
        public abstract List<User> SearchUsers(string pattern, int id);
        public abstract bool CheckFriendship(int userID, int friendID);
        public abstract bool CreateFriendship(int userID, int friendID);
        public abstract bool DeleteFriendship(int userID, int friendID);
        public abstract bool DeleteFriendshipRequest(int userID, int friendID);
        public abstract bool CheckRequest(int userID, int friendID);
        public abstract bool CreateFriendRequest(int userID, int friendID);
        public abstract List<User> GetFriendRequests(int userID);
        public abstract List<User> GetFriends(int id);
        public abstract bool ChangeUser(int id, string firstName, string lastName, string pwd, string imageLocation);
        public abstract int AddPost(int userID, string postTxt, string postImage);
        public abstract List<Post> GetPosts(int id);
        public abstract List<Post> GetPostsById(int id);
        public abstract bool LikePost(int postID, int userID);
        public abstract bool DislikePost(int postID, int userID);
        public abstract bool IsLiked(int postID, int userID);
        public abstract int LikesCount(int postID);
        public abstract bool AddComment(int postID, int userID, string comment);
        public abstract List<Comment> GetComments(int postID);
        public abstract int AddTag(string name);
        public abstract bool AddPostToTag(int tagID, int postID);
        public abstract List<string> GetTags(int postID);
        public abstract List<User> GetLikes(int postID);

    }
}
