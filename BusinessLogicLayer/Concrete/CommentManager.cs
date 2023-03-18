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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void Delete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment GetById(int id)
        {
           return  _commentDal.GetById(id);
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x=>x.BlogID == id);
        }

        public List<Comment> GetList()
        {
           return _commentDal.GetListAll();
        }

        public void Update(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
