using MiniFacebookVisual;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Template_Method
{
    public abstract class IFriendship
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

        public IFriendship()
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

        public abstract bool Procesar(FriendshipMethod method, int userID, int friendID);

        public bool Ejecutar(FriendshipMethod method, int userID, int friendID)
        {
            bool res = false;

            if (Conectar())
            {
                res = Procesar(method, userID, friendID);
                Desconectar();
            }

            return res;
        }
    }
}
