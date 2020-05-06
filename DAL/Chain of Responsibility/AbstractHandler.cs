using Core.Models;
using MiniFacebookVisual;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Chain_of_Responsibility
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
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

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            this.connectionString = Configuration.connectionString;
            return handler;
        }

        public virtual object Handle(LogIn request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
}
