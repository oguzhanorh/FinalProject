using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); // işlem sonucu ve mesajı da döndürmek istediğimden bunu yapıyoruz.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); // fiyat aralığında olan ürünleri getir olayını yapıyoruz.
        IDataResult<List<ProductDetailDto>> GetProducDetails();
        IDataResult<Product> GetById(int productId); // tek başına ürün döndürme mesela bir alışveriş sitesinin bir ürününe tıklandığında ki detay

        IResult Add(Product product); //CRUD OPERASYONLARI
    }
}
