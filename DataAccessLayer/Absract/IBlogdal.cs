using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Absract
{
    public interface IBlogdal : IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();

        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
