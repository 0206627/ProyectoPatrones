using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minifacebookAPI.Controllers
{
    [ApiController]
    [Route("api/Facebook")]
    public class FacebookController : ControllerBase
    {
        private IFacebookServices _facebookService;
        public FacebookController(IFacebookServices facebookService)
        {
            _facebookService = facebookService;
        }

        [HttpGet("LogIn")]
        public int LogIn(string email, string pwd)
        {
            return _facebookService.LogIn(email, pwd);
        }

        [HttpGet("Register")]
        public int Register(string firstName, string lastName, string email, string pwd, string gender, int year, int month, int day)
        {
            return _facebookService.Register(firstName, lastName, email, pwd, gender, new DateTime(year, month, day));
        }

        [HttpGet("GetUserById")]
        public User GetUserById(int id)
        {
            return _facebookService.GetUserById(id);
        }

        [HttpDelete("DeleteUserById")]
        public bool DeleteUserById(int id)
        {
            return _facebookService.DeleteUserById(id);
        }

        [HttpGet("CheckExistingUser")]
        public bool CheckExistingUser(string email)
        {
            return _facebookService.CheckExistingUser(email);
        }

        [HttpGet("AddProfilePicture")]
        public bool AddProfilePicture(string imageLocation, int id)
        {
            return _facebookService.AddProfilePicture(imageLocation, id);
        }

        [HttpGet("SearchUsers")]
        public List<User> SearchUsers(string pattern, int id)
        {
            return _facebookService.SearchUsers(pattern, id);
        }

        [HttpGet("CheckFriendship")]
        public bool CheckFriendship(int userID, int friendID)
        {
            return _facebookService.CheckFriendship(userID, friendID);
        }

        [HttpGet("GetFriendRequests")]
        public List<User> GetFriendRequests(int userID)
        {
            return _facebookService.GetFriendRequests(userID);
        }

        [HttpGet("CreateFriendship")]
        public bool CreateFriendship(int userID, int friendID)
        {
            return _facebookService.CreateFriendship(userID, friendID);
        }

        [HttpGet("DeleteFriendship")]
        public bool DeleteFriendship(int userID, int friendID)
        {
            return _facebookService.DeleteFriendship(userID, friendID);
        }

        [HttpGet("DeleteFriendshipRequest")]
        public bool DeleteFriendshipRequest(int userID, int friendID)
        {
            return _facebookService.DeleteFriendshipRequest(userID, friendID);
        }

        [HttpGet("CheckRequest")]
        public bool CheckRequest(int userID, int friendID)
        {
            return _facebookService.CheckRequest(userID, friendID);
        }

        [HttpGet("CreateFriendRequest")]
        public bool CreateFriendRequest(int userID, int friendID)
        {
            return _facebookService.CreateFriendRequest(userID, friendID);
        }

        [HttpGet("GetFriends")]
        public List<User> GetFriends(int id)
        {
            return _facebookService.GetFriends(id);
        }

        [HttpGet("ChangeUser")]
        public bool ChangeUser(int id, string firstName, string lastName, string pwd, string imageLocation)
        {
            return _facebookService.ChangeUser(id, firstName, lastName, pwd, imageLocation);
        }

        [HttpGet("AddPost")]
        public int AddPost(int userID, string postTxt, string postImage)
        {
            return _facebookService.AddPost(userID, postTxt, postImage);
        }

        [HttpGet("GetPosts")]
        public List<Post> GetPosts(int id)
        {
            return _facebookService.GetPosts(id);
        }

        [HttpGet("GetPostsById")]
        public List<Post> GetPostsById(int id)
        {
            return _facebookService.GetPostsById(id);
        }

        [HttpGet("LikePost")]
        public bool LikePost(int postID, int userID)
        {
            return _facebookService.LikePost(postID, userID);
        }

        [HttpGet("DislikePost")]
        public bool DislikePost(int postID, int userID)
        {
            return _facebookService.DislikePost(postID, userID);
        }

        [HttpGet("IsLiked")]
        public bool IsLiked(int postID, int userID)
        {
            return _facebookService.IsLiked(postID, userID);
        }

        [HttpGet("LikesCount")]
        public int LikesCount(int postID)
        {
            return _facebookService.LikesCount(postID);
        }

        [HttpGet("AddComment")]
        public bool AddComent(int postID, int userID, string comment)
        {
            return _facebookService.AddComment(postID, userID, comment);
        }

        [HttpGet("GetComments")]
        public List<Comment> AddComent(int postID)
        {
            return _facebookService.GetComments(postID);
        }

        [HttpGet("AddTag")]
        public int AddTag(string name)
        {
            return _facebookService.AddTag(name);
        }

        [HttpGet("AddPostToTag")]
        public bool AddPostToTag(int tagID, int postID)
        {
            return _facebookService.AddPostToTag(tagID, postID);
        }

        [HttpGet("GetTags")]
        public List<string> GetTags(int postID)
        {
            return _facebookService.GetTags(postID);
        }

        [HttpGet("GetLikes")]
        public List<User> GetLikes(int postID)
        {
            return _facebookService.GetLikes(postID);
        }


    }

}
