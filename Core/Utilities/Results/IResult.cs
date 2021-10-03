using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    //içerisinde bir tane işlem sonucu ve kullanıcı bilgilendirme mesajı olucak

   public  interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
