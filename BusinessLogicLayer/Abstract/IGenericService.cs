using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IGenericService<T>
    {

        void Add(T t);

        void Update(T t);

        void Delete(T t);

        List<T> GetList();

        T GetById(int id);

    }
}
