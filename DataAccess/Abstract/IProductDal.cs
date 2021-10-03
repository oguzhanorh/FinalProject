using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal :IEntityRepository<Product> // product için yapılandırdın.
    {
        List<ProductDetailDto> GetProductDetails();
    }
}


//Code Refactoring (kod iyileştirilmesi)