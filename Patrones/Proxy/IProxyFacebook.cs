using Core_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Models
{
    public interface IProxyFacebook
    {
        User GetUserById(int id);
        int LogIn(string email, string pwd);
        int Register(string firstName, string lastName, string email, string pwd, string gender, DateTime birthday);
        bool CheckExistingUser(string email);
        bool AddProfilePicture(string imageLocation, int id);
        List<User> SearchUsers(string pattern, int id);
        bool CheckFriendship(int userID, int friendID);
        List<User> GetFriendRequests(int userID);
        bool CreateFriendship(int userID, int friendID);
        bool DeleteFriendship(int userID, int friendID);
        bool DeleteFriendshipRequest(int userID, int friendID);
        bool CheckRequest(int userID, int friendID);
        bool CreateFriendRequest(int userID, int friendID);
        List<User> GetFriends(int id);
        bool ChangeUser(int id, string firstName, string lastName, string pwd, string imageLocation);
        int AddPost(int userID, string postTxt, string postImage);
        List<Post> GetPosts(int id);
        List<Post> GetPostsById(int id);
        bool LikePost(int postID, int userID);
        bool DislikePost(int postID, int userID);
        bool IsLiked(int postID, int userID);
        int LikesCount(int postID);
        bool AddComment(int postID, int userID, string comment);
        List<Comment> GetComments(int postID);
        int AddTag(string name);
        bool AddPostToTag(int tagID, int postID);
        List<string> GetTags(int postID);
        List<User> GetLikes(int postID);

    }
}
