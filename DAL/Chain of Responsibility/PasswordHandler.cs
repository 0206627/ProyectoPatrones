using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Chain_of_Responsibility
{
    public class PasswordHandler : AbstractHandler
    {
        public override object Handle(LogIn request)
        {
            if (request.GetEmail() == request.GetPwd()) return request.GetID();
            else return base.Handle(request);
        }
    }
}
