using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle // yaptığın yazılıma yeni bir özellik ekliyorsan mevcutta ki hiç bir koda 
    //Ne de olsa interface hanginisin referans tuttuğunu bildiğim için new yapıyorum parantez içinde.
    //DTO = DATA TRANSFORMASSİON OBJECT
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }
            
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProducDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }


            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}


