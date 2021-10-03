using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint
    // referans tip olabilir
    // referans tipi ya T olucak ya da IEntityden olucak demek veya IEntity implement eden bir nesne olabilir.
    // IEntity newlenemeceğinden dolayı 
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class, IEntity,new() //çalışacağımız tip T
        
    {
        //List<T> GetAll filtreleme işlemini expression ile yapıyoruz.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter=null); //ben bu yapı ile kategori sayesinde ayrı ayrı metod yazmama gerek kalmıcak.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

       
    }
}
