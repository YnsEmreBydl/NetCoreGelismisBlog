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
    public class BlogManager : IBlogService
    {

        IBlogdal _blogdal;

        public BlogManager(IBlogdal blogdal)
        {
            _blogdal = blogdal;
        }

      
      
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogdal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriterBlogManager(int id)
        {
            return _blogdal.GetListWithCategoryByWriter(id);
        }
      

        public List<Blog> GetBlogListById(int id)
        {
            return _blogdal.GetListAll(x => x.BlogID == id);
        }

       

        public List<Blog> GetLast3Blog()
        {
            return _blogdal.GetListAll().Take(3).ToList();
        }


        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogdal.GetListAll(x => x.WriterID==id);
        }

        public void Add(Blog t)
        {
            _blogdal.Insert(t);
        }

        public void Update(Blog t)
        {
            _blogdal.Update(t);
        }

        public void Delete(Blog t)
        {
            _blogdal.Delete(t);
        }

        public List<Blog> GetList()
        {
            return _blogdal.GetListAll();
        }

        public Blog GetById(int id)
        {
            return _blogdal.GetById(id);
        }
    }
}
