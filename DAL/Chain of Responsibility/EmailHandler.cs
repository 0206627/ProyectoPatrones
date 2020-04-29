using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Chain_of_Responsibility
{
    public class EmailHandler : AbstractHandler
    {
        public override object Handle(LogIn request)
        {

            Conectar();

            string sql = "select * from users where email = '" + request.GetEmail() + "';";
            var adaptador = new SqlDataAdapter();
            dataset = new DataSet();

            adaptador.SelectCommand = new SqlCommand(sql, mySqlConnection);
            adaptador.Fill(dataset, "Users");

            Desconectar();

            if (!(dataset.Tables["Users"].Rows.Count > 0)) return 0;
            else
            {
                request.SetEmail(dataset.Tables["Users"].Rows[0]["pwd"].ToString());
                request.SetID(Convert.ToInt32(dataset.Tables["Users"].Rows[0]["userID"]));
                return base.Handle(request);
            }

        }
    }
}
