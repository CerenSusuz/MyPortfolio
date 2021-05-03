using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Concrete.EF.Context;

namespace DataAccess.Concrete.EF.DALs
{
    public class EFCommentDAL : EFEntityRepositoryBase<Comment, PortfolioDbContext>, ICommentDAL
    {
        public List<CommentDetail> GetCommentsDetails(Expression<Func<CommentDetail, bool>> filter = null)
        {
            using (PortfolioDbContext context = new PortfolioDbContext())
            {
                var result = from comment in context.Comments

                             join user in context.Users
                             on comment.UserId equals user.Id

                             join blog in context.Blogs
                             on comment.BlogId equals blog.Id

                             select new CommentDetail()
                             {
                                 Id = comment.Id,
                                 UserId = user.Id,
                                 User = user.FirstName + user.LastName,
                                 WrittenDate = comment.CreatedAt,
                                 BlogId = blog.Id,
                                 Blog = blog.Title,
                                 Content = comment.Content
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
