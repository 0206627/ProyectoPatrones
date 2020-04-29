using Core.Models;
using DAL.Template_Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class FacebookData : IFacebookData
    {
        public FacebookData()
        {
        }

        public override int LogIn(string email, string pwd)
        {
            Conectar();

            string sql = "select * from users where email = '" + email + "';";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();
            int res = 0;

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            //Console.WriteLine("Length " + dataset.Tables["Users"].Rows.Count);
            if (dataset.Tables["Users"].Rows[0]["pwd"].ToString() == pwd) res = Convert.ToInt32(dataset.Tables["Users"].Rows[0]["userID"]);

            Desconectar();

            return res;
        }

        public override int Register(string firstName, string lastName, string email, string pwd, string gender, DateTime birthday)
        {

            Conectar();

            SqlCommand cmd = new SqlCommand("INSERT INTO users (firstName, lastName, email, pwd, gender, birthday, dateJoined) VALUES (@firstName, @lastName, @email, @pwd, @gender, @birthday, @dateJoined);SELECT SCOPE_IDENTITY();", mySqlConnection);

            int res = 0;

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@birthday", birthday);
            cmd.Parameters.AddWithValue("@dateJoined", DateTime.Now);

            object obj = cmd.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {
                res = Convert.ToInt32(obj);
            }

            Desconectar();

            return res;

        }

        public override User GetUserById(int id)
        {
            Conectar();

            string sql = "select * from users where userID = " + id + ";";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            var res = dataset.Tables["Users"].Rows[0];

            Desconectar();

            return new User(Convert.ToInt32(res["userID"]), res["firstName"].ToString(), res["lastName"].ToString(), res["email"].ToString(), res["pwd"].ToString(), res["gender"].ToString(), Convert.ToDateTime(res["birthday"]), Convert.ToDateTime(res["dateJoined"]), res["profilePicture"].ToString());
        }

        public override bool DeleteUserById(int id)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("delete from users where userID =" + id + ";", mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            if (resCmd != 0) res = true;

            Desconectar();

            return res;
        }

        public override bool CheckExistingUser(string email)
        {
            Conectar();

            string sql = "select * from users where email = '" + email + "';";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            Desconectar();

            return (dataset.Tables["Users"].Rows.Count > 0);

        }

        public override bool AddProfilePicture(string imageLocation, int id)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("update users set profilePicture = '" + imageLocation + "' where userID = " + id + ";", mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            Console.WriteLine("resCmd: " + resCmd.ToString());

            if (resCmd != 0) res = true;

            Desconectar();

            return res;
        }

        public override List<User> SearchUsers(string pattern, int id)
        {
            Conectar();

            List<User> users = new List<User>();

            string sql = "select * from users where firstName like '%" + pattern + "%' or lastName like '%" + pattern + "%' and not userID = " + id + ";";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            foreach (DataRow row in dataset.Tables["Users"].Rows)
            {
                users.Add(new User(Convert.ToInt32(row["userID"]), row["firstName"].ToString(), row["lastName"].ToString(), row["email"].ToString(), row["pwd"].ToString(), row["gender"].ToString(), Convert.ToDateTime(row["birthday"]), Convert.ToDateTime(row["dateJoined"]), row["profilePicture"].ToString()));
            }

            Desconectar();

            return users;
        }

        public override bool CheckFriendship(int userID, int friendID)
        {
            return Friendship.GetInstance().Ejecutar(FriendshipMethod.CheckFriendship, userID, friendID);
        }

        public override List<User> GetFriendRequests(int userID)
        {
            Conectar();

            List<User> users = new List<User>();

            string sql = $"select * from users where userID in (select friendID from friends where userID = {userID} and accepted = 0);";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            foreach (DataRow row in dataset.Tables["Users"].Rows)
            {
                users.Add(new User(Convert.ToInt32(row["userID"]), row["firstName"].ToString(), row["lastName"].ToString(), row["email"].ToString(), row["pwd"].ToString(), row["gender"].ToString(), Convert.ToDateTime(row["birthday"]), Convert.ToDateTime(row["dateJoined"]), row["profilePicture"].ToString()));
            }

            Desconectar();

            return users;
        }

        public override bool CreateFriendship(int userID, int friendID)
        {
            return Friendship.GetInstance().Ejecutar(FriendshipMethod.CreateFriendship, userID, friendID);
        }

        public override bool DeleteFriendship(int userID, int friendID)
        {
            return Friendship.GetInstance().Ejecutar(FriendshipMethod.DeleteFriendship, userID, friendID);
        }

        public override bool DeleteFriendshipRequest(int userID, int friendID)
        {
            return Friendship.GetInstance().Ejecutar(FriendshipMethod.DeleteFriendshipRequest, userID, friendID);
        }

        public override bool CheckRequest(int userID, int friendID)
        {
            return Friendship.GetInstance().Ejecutar(FriendshipMethod.CheckRequest, userID, friendID);
        }

        public override bool CreateFriendRequest(int userID, int friendID)
        {
            return Friendship.GetInstance().Ejecutar(FriendshipMethod.CreateFriendRequest, userID, friendID);
        }

        public override List<User> GetFriends(int id)
        {
            Conectar();

            List<User> users = new List<User>();

            string sql = $"select * from users where userID in (select friendID from friends where userID = {id} and accepted = 1);";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            foreach (DataRow row in dataset.Tables["Users"].Rows)
            {
                users.Add(new User(Convert.ToInt32(row["userID"]), row["firstName"].ToString(), row["lastName"].ToString(), row["email"].ToString(), row["pwd"].ToString(), row["gender"].ToString(), Convert.ToDateTime(row["birthday"]), Convert.ToDateTime(row["dateJoined"]), row["profilePicture"].ToString()));
            }

            Desconectar();

            return users;
        }

        public override bool ChangeUser(int id, string firstName, string lastName, string pwd, string imageLocation)
        {
            Conectar();

            string sql = $"update users set firstName = '{firstName}', lastName = '{lastName}', pwd = '{pwd}', profilePicture = '{imageLocation}' where userID = {id};";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            if (resCmd != 0) res = true;

            Desconectar();

            return res;
        }

        public override int AddPost(int userID, string postTxt, string postImage)
        {
            Conectar();

            string sql = $"insert into post (userID, postTxt, postImage, postDate) values(@userID, @postTxt, @postImage, @postDate);SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@postTxt", postTxt);
            cmd.Parameters.AddWithValue("@postImage", postImage);
            cmd.Parameters.AddWithValue("@postDate", DateTime.Now);

            int res = 0;

            object obj = cmd.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {
                res = Convert.ToInt32(obj);
            }

            Desconectar();

            return res;
        }

        public override List<Post> GetPosts(int id) { 

            Conectar();

            List<Post> posts = new List<Post>();

            string sql = $"select * from post where postDate >= DATEADD(day, -2, GetDate()) and (userID = {id} or userID in (select friendID from friends where userID = {id} and accepted = 1)) order by postDate desc;";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Posts");

            foreach (DataRow row in dataset.Tables["Posts"].Rows)
            {
                posts.Add(new Post(Convert.ToInt32(row["postID"]), Convert.ToInt32(row["userID"]), row["postTxt"].ToString(), row["postImage"].ToString(), Convert.ToDateTime(row["postDate"])));
            }

            Desconectar();

            return posts;
        }

        public override List<Post> GetPostsById(int id)
        {
            Conectar();

            List<Post> posts = new List<Post>();

            string sql = $"select * from post where postDate >= DATEADD(day, -100, GetDate()) and userID = {id} order by postDate desc;";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Posts");

            foreach (DataRow row in dataset.Tables["Posts"].Rows)
            {
                posts.Add(new Post(Convert.ToInt32(row["postID"]), Convert.ToInt32(row["userID"]), row["postTxt"].ToString(), row["postImage"].ToString(), Convert.ToDateTime(row["postDate"])));
            }

            Desconectar();

            return posts;
        }

        public override bool LikePost(int postID, int userID)
        {
            Conectar();

            string sql = $"insert into likes values(@postID, @userID);";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            cmd.Parameters.AddWithValue("@postID", postID);
            cmd.Parameters.AddWithValue("@userID", userID);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            if (resCmd != 0) res = true;

            Desconectar();

            return res;
        }

        public override bool DislikePost(int postID, int userID)
        {
            Conectar();

            string sql = $"delete from likes where postID = {postID} and userID = {userID};";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            Console.WriteLine("resCmd: " + resCmd.ToString());

            if (resCmd != 0)
            {
                res = true;
            }

            Desconectar();

            return res;
        }
        public override bool IsLiked(int postID, int userID)
        {
            Conectar();

            string sql = $"select * from likes where postID = {postID} and userID = {userID};";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Likes");

            Desconectar();

            return (dataset.Tables["Likes"].Rows.Count > 0);
        }

        public override int LikesCount(int postID)
        {
            Conectar();

            string sql = $"select count(postID) as count from likes where postID = {postID};";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Likes");

            Desconectar();

            return Convert.ToInt32(dataset.Tables["Likes"].Rows[0]["count"]);
        }

        public override bool AddComment(int postID, int userID, string comment)
        {
            Conectar();

            string sql = $"insert into comments values(@postID, @userID, @comment);";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            cmd.Parameters.AddWithValue("@postID", postID);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@comment", comment);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            if (resCmd != 0) res = true;

            Desconectar();

            return res;
        }

        public override List<Comment> GetComments(int postID)
        {
            Conectar();

            List<Comment> comments = new List<Comment>();

            string sql = $"select * from comments where postID = {postID};";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Comments");

            foreach (DataRow row in dataset.Tables["Comments"].Rows)
            {
                comments.Add(new Comment(Convert.ToInt32(row["postID"]), Convert.ToInt32(row["userID"]), row["comment"].ToString()));
            }

            Desconectar();

            return comments;
        }

        public override int AddTag(string nombre)
        {
            Conectar();

            char[] separator = { ' ' };
            Int32 count = 2;
            String[] textToSend = nombre.Split(separator, count);

            string sql = $"select userID from users where firstName = '{textToSend[0]}' and lastName = '{textToSend[1]}';";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "User");

            int userID = Convert.ToInt32(dataset.Tables["User"].Rows[0]["userID"]);

            sql = $"select * from tags where userID = {userID} and postID is NULL;";
            adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Tags");

            if (dataset.Tables["Tags"].Rows.Count > 0) return -1;

            SqlCommand cmd = new SqlCommand($"INSERT INTO tags (userID) values ({userID});SELECT SCOPE_IDENTITY();", mySqlConnection);

            int res = 0;

            object obj = cmd.ExecuteScalar();

            if (!obj.Equals(DBNull.Value))
            {
                res = Convert.ToInt32(obj);
            }

            Desconectar();

            return res;
        }

        public override bool AddPostToTag(int tagID, int postID)
        {
            Conectar();

            string sql = $"update tags set postID = {postID} where tagID = {tagID};";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            if (resCmd != 0) res = true;

            Desconectar();

            return res;
        }

        public override List<string> GetTags(int postID)
        {
            Conectar();

            List<string> people = new List<string>();

            string sql = $"select firstName, lastName from users where userID in (select userID from tags where postID = {postID});";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "People");

            foreach (DataRow row in dataset.Tables["People"].Rows)
            {
                people.Add($"{row["firstName"]} {row["lastName"]}");
            }

            Desconectar();

            return people;
        }

        public override List<User> GetLikes(int postID)
        {
            Conectar();

            List<User> users = new List<User>();

            string sql = $"select * from users where userID in (select userID from likes where postID = {postID});";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            foreach (DataRow row in dataset.Tables["Users"].Rows)
            {
                users.Add(new User(Convert.ToInt32(row["userID"]), row["firstName"].ToString(), row["lastName"].ToString(), row["email"].ToString(), row["pwd"].ToString(), row["gender"].ToString(), Convert.ToDateTime(row["birthday"]), Convert.ToDateTime(row["dateJoined"]), row["profilePicture"].ToString()));
            }

            Desconectar();

            return users;
        }
    }
}
