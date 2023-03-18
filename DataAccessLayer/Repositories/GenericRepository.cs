using DataAccessLayer.Absract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        Context cx = new Context();
        public void Delete(T t)
        {
            cx.Remove(t);
            cx.SaveChanges();
        }

        public T GetById(int id)
        {
            return cx.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return cx.Set<T>().ToList();
            
        }

        public void Insert(T t)
        {
            cx.Add(t);
            cx.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return cx.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
            cx.Update(t);
            cx.SaveChanges();
        }
    }
}
