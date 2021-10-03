using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //birden fazla ürün döndürebileceğimden IDTO MESsage gibi o yüzden
    //T İLE NE DÖNDÜRÜRSEN DÖNDÜR DİYORUZ (GENERİC)
    public interface IDataResult<T>:IResult
    {
        T Data { get; } //ürünlerimiz


    }
}
