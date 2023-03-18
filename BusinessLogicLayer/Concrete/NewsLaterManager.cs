using BusinessLogicLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class NewsLaterManager : INewsLaterService
    {
        INewsLaterDal _newsLaterDal;

        public NewsLaterManager(INewsLaterDal newsLaterDal)
        {
            _newsLaterDal = newsLaterDal;
        }

        public void Add(NewsLater t)
        {
            _newsLaterDal.Insert(t);
        }

        public void Delete(NewsLater t)
        {
            _newsLaterDal.Delete(t);
        }

        public NewsLater GetById(int id)
        {
            return _newsLaterDal.GetById(id);
        }

        public List<NewsLater> GetList()
        {
            return _newsLaterDal.GetListAll();
        }

        public void Update(NewsLater t)
        {
            _newsLaterDal.Update(t);
        }
    }
}
