using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {

        ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        [SecuredOperation("admin,user,moderator")]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Add(Comment comment)
        {
            _commentDAL.Add(comment);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user,moderator")]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Delete(Comment comment)
        {
            _commentDAL.Delete(comment);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Comment> Get(int id)
        {
            return new SuccessDataResult<Comment>(_commentDAL.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDAL.GetAll());
        }

        public IDataResult<List<CommentDetail>> GetCommentDetail()
        {
            return new SuccessDataResult<List<CommentDetail>>(_commentDAL.GetCommentsDetails());
        }

        public IDataResult<List<CommentDetail>> GetCommentDetails(int id)
        {
            return new SuccessDataResult<List<CommentDetail>>(_commentDAL.GetCommentsDetails(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CommentDetail>> GetCommentsByBlogId(int id)
        {
            return new SuccessDataResult<List<CommentDetail>>(_commentDAL.GetCommentsDetails(c => c.BlogId == id));
        }

        [CacheAspect]
        public IDataResult<List<CommentDetail>> GetCommentsByUserId(int id)
        {
            return new SuccessDataResult<List<CommentDetail>>(_commentDAL.GetCommentsDetails(c => c.UserId == id));
        }

        [SecuredOperation("admin,user,moderator")]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Update(Comment comment)
        {
            _commentDAL.Update(comment);
            return new SuccessResult();
        }
    }
}
