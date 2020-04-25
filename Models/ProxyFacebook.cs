using Core_API.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebookVisual.Models
{
    public class ProxyFacebook : IProxyFacebook
    {
        private RestClient _client;
        private string _urlBase = "https://localhost:44373/api/Facebook/";

        public ProxyFacebook()
        {
            _client = new RestClient(_urlBase);
        }

        public bool AddProfilePicture(string imageLocation, int id)
        {
            var request = new RestRequest($"AddProfilePicture?imageLocation={imageLocation}&id={id}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool CheckExistingUser(string email)
        {
            var request = new RestRequest($"CheckExistingUser?email={email}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool CheckFriendship(int userID, int friendID)
        {
            var request = new RestRequest($"CheckFriendship?userID={userID}&friendID={friendID}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool CheckRequest(int userID, int friendID)
        {
            var request = new RestRequest($"CheckRequest?userID={userID}&friendID={friendID}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool CreateFriendRequest(int userID, int friendID)
        {
            var request = new RestRequest($"CreateFriendRequest?userID={userID}&friendID={friendID}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool CreateFriendship(int userID, int friendID)
        {
            var request = new RestRequest($"CreateFriendship?userID={userID}&friendID={friendID}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool DeleteFriendship(int userID, int friendID)
        {
            var request = new RestRequest($"DeleteFriendship?userID={userID}&friendID={friendID}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public bool DeleteFriendshipRequest(int userID, int friendID)
        {
            var request = new RestRequest($"DeleteFriendshipRequest?userID={userID}&friendID={friendID}");
            var response = _client.Get<bool>(request);
            return response.Data;
        }

        public List<User> GetFriendRequests(int userID)
        {
            var request = new RestRequest($"GetFriendRequests?userID={userID}");
            var response = _client.Get<List<User>>(request);
            return response.Data;
        }

        public List<User> GetFriends(int id)
        {
            var request = new RestRequest($"GetFriends?id={id}");
            var response = _client.Get<List<User>>(request);
            return response.Data;
        }

        public User GetUserById(int id)
        {
            var request = new RestRequest($"GetUserById?id={id}");
            var response = _client.Get<User>(request);
            return response.Data;
        }

        public int LogIn(string email, string pwd)
        {
            var request = new RestRequest($"LogIn?email={email}&pwd={pwd}");
            var response = _client.Get<int>(request);
            return response.Data;
        }

        public int Register(string firstName, string lastName, string email, string pwd, string gender, DateTime birthday)
        {
            var request = new RestRequest($"Register?firstName={firstName}&lastName={lastName}&email={email}&pwd={pwd}&gender={gender}&year={birthday.Year.ToString()}&month={birthday.Month.ToString()}&day={birthday.Day.ToString()}");
            var response = _client.Get<int>(request);
            return response.Data;
        }

        public List<User> SearchUsers(string pattern, int id)
        {
            var request = new RestRequest($"SearchUsers?pattern={pattern}&id={id}");
            var response = _client.Get<List<User>>(request);
            return response.Data;
        }
    }
}
