using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Template_Method
{
    public class Friendship : IFriendship
    {
        private static Friendship _friendship = null;

        public Friendship() : base()
        {
        }

        public static Friendship GetInstance()
        {
            if (_friendship == null)
            {
                _friendship = new Friendship();
            }

            return _friendship;
        }
        public override bool Procesar(FriendshipMethod method, int userID, int friendID)
        {
            switch ((int)method)
            {
                case 1:
                    return CheckFriendship(userID, friendID);
                case 2:
                    return CreateFriendship(userID, friendID);
                case 3:
                    return DeleteFriendship(userID, friendID);
                case 4:
                    return DeleteFriendshipRequest(userID, friendID);
                case 5:
                    return CheckRequest(userID, friendID);
                case 6:
                    return CreateFriendRequest(userID, friendID);
                default:
                    return false;
            }
        }

        private bool CheckFriendship(int userID, int friendID)
        {
            string sql = $"select * from friends where userID = {userID} and friendID = {friendID} and accepted = 1";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            return (dataset.Tables["Users"].Rows.Count > 0);
        }
        private bool CreateFriendship(int userID, int friendID)
        {
            string sql = $"update friends set accepted = 1 where userID = {userID} and friendID = {friendID};";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            if (resCmd != 0)
            {
                sql = $"insert into friends values({friendID},{userID},1);";
                cmd = new SqlCommand(sql, mySqlConnection);

                resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

                Console.WriteLine("resCmd: " + resCmd.ToString());

                if (resCmd != 0)
                {
                    res = true;
                }

            }

            return res;
        }
        private bool DeleteFriendship(int userID, int friendID)
        {
            string sql = $"delete from friends where userID = {userID} and friendID = {friendID};";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            Console.WriteLine("resCmd: " + resCmd.ToString());

            if (resCmd != 0)
            {
                sql = $"delete from friends where userID = {friendID} and friendID = {userID};";
                cmd = new SqlCommand(sql, mySqlConnection);

                resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

                Console.WriteLine("resCmd: " + resCmd.ToString());

                if (resCmd != 0)
                {
                    res = true;
                }
            }

            return res;
        }
        private bool DeleteFriendshipRequest(int userID, int friendID)
        {
            string sql = $"delete from friends where userID = {userID} and friendID = {friendID};";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            Console.WriteLine("resCmd: " + resCmd.ToString());

            if (resCmd != 0)
            {
                res = true;
            }

            return res;
        }
        private bool CheckRequest(int userID, int friendID)
        {
            string sql = $"select * from friends where userID = {userID} and friendID = {friendID} and accepted = 0;";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            return (dataset.Tables["Users"].Rows.Count > 0);
        }
        private bool CreateFriendRequest(int userID, int friendID)
        {
            string sql = $"insert into friends values({userID},{friendID},0);";
            SqlCommand cmd = new SqlCommand(sql, mySqlConnection);

            bool res = false;

            int resCmd = Convert.ToInt32(cmd.ExecuteNonQuery());

            Console.WriteLine("resCmd: " + resCmd.ToString());

            if (resCmd != 0)
            {
                res = true;
            }

            return res;
        }
    }
}
