using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Entityframework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>//verileen göre çalışıcam demek.
    
        where TEntity: class, IEntity, new() // IEntity yazamasın diye new yaptık
        where TContext: DbContext,new() //yapımız bu şekilde olucak.
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext()) //using bittiği anda topluyoruz yani belleği hızlıcaz temizleme
            {
                var addedEntity = context.Entry(entity); //git eşleştir veri kaynağından
                addedEntity.State = EntityState.Added; //veritabanında yapacağı işlem
                context.SaveChanges(); //ekle yukarıdaki işlemleri gerçekleştir.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //using bittiği anda topluyoruz yani belleği hızlıcaz temizleme
            {
                var deletedEntity = context.Entry(entity); //git eşleştir veri kaynağından
                deletedEntity.State = EntityState.Deleted; //veritabanında yapacağı işlem
                context.SaveChanges(); //ekle yukarıdaki işlemleri gerçekleştir.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        { //tek datayı getirir
          //Standart bir kod sadece product kısımları customer veya category olucak.
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //tüm dataları getir
            using (TContext context = new TContext())
            {
                //db setteki product tablosuna yerleş ve tüm tabloyu listeye çevir ve bana ver demek
                //yani arka planda select * from olayını yapıyor.
                //Turnery operatörü eğer filtre null ise hepsini getir değilse 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //using bittiği anda topluyoruz yani belleği hızlıcaz temizleme
            {
                var updatedEntity = context.Entry(entity); //git eşleştir veri kaynağından
                updatedEntity.State = EntityState.Modified; //veritabanında yapacağı işlem
                context.SaveChanges(); //ekle yukarıdaki işlemleri gerçekleştir.
            }
        }
    }
}
