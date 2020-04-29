using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Chain_of_Responsibility
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(LogIn request);
    }
}
