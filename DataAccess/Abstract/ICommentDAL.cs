using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICommentDAL : IEntityRepository<Comment>
    {
        List<CommentDetail> GetCommentsDetails(Expression<Func<CommentDetail, bool>> filter = null);
    }
}
