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
    public class NotificationManager : INotificationService
    {

        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void Delete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetListAll();
        }

        public void Update(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}
