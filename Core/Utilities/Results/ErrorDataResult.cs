using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //işlem sonucunu aşağıda ki gibi default true vermiş olduk eğer mesaj olayına 
        //girmek istersek olayı böyle
        public ErrorDataResult(T data, string message) : base(data, true, message)
        {

        }
        //mesaj olayına girmek istemezse aşağıda ki yapı
        public ErrorDataResult(T data) : base(data, true)
        {

        }

        //default return tipi int'tir 
        public ErrorDataResult(string message) : base(default, true, message)
        {

        }
        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
