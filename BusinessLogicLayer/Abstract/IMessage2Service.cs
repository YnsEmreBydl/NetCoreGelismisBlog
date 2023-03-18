using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetInboxWithByWriter(int id);

        
    }
}
