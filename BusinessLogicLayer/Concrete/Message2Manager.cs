using BusinessLogicLayer.Abstract;
using DataAccessLayer.Absract;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            this.message2Dal = message2Dal;
        }

        public void Add(Message2 t)
        {
            message2Dal.Insert(t);
        }

        public void Delete(Message2 t)
        {
            message2Dal.Delete(t);
        }

        public Message2 GetById(int id)
        {
            return message2Dal.GetById(id);
        }

     

        public List<Message2> GetInboxWithByWriter(int id)
        {
            return message2Dal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return message2Dal.GetListAll();
        }

        public void Update(Message2 t)
        {
            message2Dal.Update(t);
        }
    }
}
