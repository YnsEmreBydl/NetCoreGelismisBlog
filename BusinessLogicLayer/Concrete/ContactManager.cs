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
    public class ContactManager : IContactService
    {

        IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void Add(Contact t)
        {
            contactDal.Insert(t);
        }

        public void Delete(Contact t)
        {
            contactDal.Delete(t);
        }

        public Contact GetById(int id)
        {
            return contactDal.GetById(id);
        }

        public List<Contact> GetList()
        {
            return contactDal.GetListAll();
        }

        public void Update(Contact t)
        {
            contactDal.Update(t);
        }
    }
}
