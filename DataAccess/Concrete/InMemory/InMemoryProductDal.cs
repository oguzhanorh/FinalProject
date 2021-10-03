using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //classlar için global değişken olduğundan _ ile tanımlarız.
        public InMemoryProductDal() //constructor oluşturma bloğu ctor
        {
            //Sanki bize oracle,sql,postgre gibi veritabanlarından geliyormuş gibi simule ediyoruz hayali olarak.
            _products = new List<Product> {
                new Product{ProductId = 1, CategoryId = 1, ProductName ="Book ",UnitPrice = 15,UnitsInStock = 20 }, //ilk ürün
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Camera", UnitPrice = 500, UnitsInStock = 3}, //ikinci ürün
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Phone", UnitPrice = 2500, UnitsInStock = 2}, //
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Mouse ", UnitPrice = 85, UnitsInStock = 1},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Keyboard", UnitPrice = 150, UnitsInStock = 65},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);

        }

        public void Delete(Product product)
        {
            //LINQ = Language Integrated Query
            //Lambda
            //.Net 'de LINQ alışmak gerekiyor foreach ile aynı işlemi yapıyor.
            Product productToDelete = null;
            //Product productToDelete = new Product(); // ÇOK HATALI BİR KOD DİYELİM 201 REF.NO BOŞU BOŞUNA BELLEĞİ YORUYORUZ.
            //foreach (var p in _products) //tek tek dolaş eğer id ler eşleşirse onu sil diyoruz.
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // foreach ile aynı işlemi yapar. Her p için git bak p'nin product id'si benim gönderdiğime eşitmi bak.
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() //business ürün istediğinden direk olarak return ile ürünleri döndürüyoruz.
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return  _products.Where(p => p.CategoryId == categoryId).ToList(); // içindeki şarta uyan bütün elemanlar bir liste haline getirir ve onu döndürü where koşulu bu işe yarar tıpkı sql de ki gibi.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //işin mantığı bu şekilde fakat entityframework bu kısmı otomatik hallediyor.
            // gönderdiğim ürün Id'sine sahip olan ürün id'sini bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
