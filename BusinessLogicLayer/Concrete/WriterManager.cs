using BusinessLogicLayer.Abstract;
using DataAccessLayer.Absract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void Delete(Writer t)
        {
            _writerDal.Delete(t);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.GetListAll();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);
        }

        public void Update(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
