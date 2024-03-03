using DataAccesssLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesssLayer.Concrete.Repositories1
{
    public class GenericRepository<T> : IRepository<T> where T : class //t class olacak
    {
        Context c=new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>(); //obje dısarıdan gönderilen T değeri olacak
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State= EntityState.Deleted;
           // _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //(a) var Liste=c.Categories.Where(x =>x.CategoryName=="kitap").ToList();
            return _object.SingleOrDefault(filter);
        }

        public List<T> List()
        {
            //(a) var kayit = sinif.ogrenciler.FirstOrDefault(x => x.Id == 1);
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();  
        }

        public void Update(T p)
        {
            var updatedEntity=c.Entry(p);
            updatedEntity.State= EntityState.Modified;
            c.SaveChanges();
        }

        public void İnsert(T p)
        {
            var addedEntity=c.Entry(p);
            addedEntity.State= EntityState.Added;
           // _object.Add(p);
            c.SaveChanges();
        }
    }
}
