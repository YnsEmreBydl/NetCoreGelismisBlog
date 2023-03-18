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
    public class AboutManager : IAboutService
    {

        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void Add(About t)
        {
            _aboutdal.Insert(t);
        }

        public void Delete(About t)
        {
            _aboutdal.Delete(t);
        }

        public About GetById(int id)
        {
            return _aboutdal.GetById(id);
        }

        public List<About> GetList()
        {
            return _aboutdal.GetListAll();
        }

        public void Update(About t)
        {
            _aboutdal.Update(t);
        }
    }
}
