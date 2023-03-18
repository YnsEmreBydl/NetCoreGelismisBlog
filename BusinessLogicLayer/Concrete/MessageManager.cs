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
    public class MessageManager : IMessageService
    {

        IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void Add(Message t)
        {
            messageDal.Insert(t);
        }

        public void Delete(Message t)
        {
            messageDal.Delete(t);
        }

        public Message GetById(int id)
        {
            return messageDal.GetById(id);
        }

        public List<Message> GetList()
        {
            return messageDal.GetListAll();
        }

        public List<Message> GetInboxWithByWriter(string p)
        {
            return messageDal.GetListAll(x => x.Receiver == p);
        }

        public void Update(Message t)
        {
            messageDal.Update(t);
        }
    }
}
