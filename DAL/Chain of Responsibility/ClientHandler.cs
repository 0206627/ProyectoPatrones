using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Chain_of_Responsibility
{
    public class ClientHandler
    {
        public static object ClientCode(AbstractHandler handler, LogIn request)
        {

            var result = handler.Handle(request);

            if (result != null)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
