using Core.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class FacebookService : IFacebookServices
    {
        private IFacebookData _facebookData;

        public FacebookService()
        {
            _facebookData = new FacebookData();
        }

        public int AddPost(int userID, string postTxt, string postImage)
        {
            return _facebookData.AddPost(userID, postTxt, postImage);
        }

        public bool AddProfilePicture(string imageLocation, int id)
        {
            return _facebookData.AddProfilePicture(imageLocation, id);
        }

        public bool ChangeUser(int id, string firstName, string lastName, string pwd, string imageLocation)
        {
            return _facebookData.ChangeUser(id, firstName, lastName, pwd, imageLocation);
        }

        public bool CheckExistingUser(string email)
        {
            return _facebookData.CheckExistingUser(email);
        }

        public bool CheckFriendship(int userID, int friendID)
        {
            return _facebookData.CheckFriendship(userID, friendID);
        }

        public bool CheckRequest(int userID, int friendID)
        {
            return _facebookData.CheckRequest(userID, friendID);
        }

        public bool CreateFriendRequest(int userID, int friendID)
        {
            return _facebookData.CreateFriendRequest(userID, friendID);
        }

        public bool CreateFriendship(int userID, int friendID)
        {
            return _facebookData.CreateFriendship(userID, friendID);
        }

        public bool DeleteFriendship(int userID, int friendID)
        {
            return _facebookData.DeleteFriendship(userID, friendID);
        }

        public bool DeleteFriendshipRequest(int userID, int friendID)
        {
            return _facebookData.DeleteFriendshipRequest(userID, friendID);
        }

        public bool DeleteUserById(int id)
        {
            return _facebookData.DeleteUserById(id);
        }

        public List<User> GetFriendRequests(int userID)
        {
            return _facebookData.GetFriendRequests(userID);
        }

        public List<User> GetFriends(int id)
        {
            return _facebookData.GetFriends(id);
        }

        public List<Post> GetPosts(int id)
        {
            return _facebookData.GetPosts(id);
        }

        public List<Post> GetPostsById(int id)
        {
            return _facebookData.GetPostsById(id);
        }

        public User GetUserById(int id)
        {
            return _facebookData.GetUserById(id);
        }

        public bool LikePost(int postID, int userID)
        {
            return _facebookData.LikePost(postID, userID);
        }

        public bool DislikePost(int postID, int userID)
        {
            return _facebookData.DislikePost(postID, userID);
        }

        public bool IsLiked(int postID, int userID)
        {
            return _facebookData.IsLiked(postID, userID);
        }
        public int LogIn(string email, string pwd)
        {
            return _facebookData.LogIn(email, pwd);
        }

        public int Register(string firstName, string lastName, string email, string pwd, string gender, DateTime birthday)
        {
            return _facebookData.Register(firstName, lastName, email, pwd, gender, birthday);
        }

        public List<User> SearchUsers(string pattern, int id)
        {
            return _facebookData.SearchUsers(pattern, id);
        }

        public int LikesCount(int postID)
        {
            return _facebookData.LikesCount(postID);
        }

        public bool AddComment(int postID, int userID, string comment)
        {
            return _facebookData.AddComment(postID, userID, comment);
        }

        public List<Comment> GetComments(int postID)
        {
            return _facebookData.GetComments(postID);
        }

        public int AddTag(string name)
        {
            return _facebookData.AddTag(name);
        }

        public bool AddPostToTag(int tagID, int postID)
        {
            return _facebookData.AddPostToTag(tagID, postID);
        }

        public List<string> GetTags(int postID)
        {
            return _facebookData.GetTags(postID);
        }

        public List<User> GetLikes(int postID)
        {
            return _facebookData.GetLikes(postID);
        }
    }
}
