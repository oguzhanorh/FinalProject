using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //işlem sonucunu aşağıda ki gibi default true vermiş olduk eğer mesaj olayına 
        //girmek istersek olayı böyle
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        //mesaj olayına girmek istemezse aşağıda ki yapı
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        //default return tipi int'tir 
        public SuccessDataResult(string message) : base(default, true, message)
        {
         
        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
