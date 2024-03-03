using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesssLayer.Abstract
{
    public interface IRepository<T> //burada sadece metodların başlıklarını yazıyoruz
    {
        List<T> List();
        void Update(T p);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T p);
        void İnsert(T p);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
