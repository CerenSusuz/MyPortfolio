using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService 
    {
        IResult Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
        IDataResult<Comment> Get(int id);
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<CommentDetail>> GetCommentsByBlogId(int id);
        IDataResult<List<CommentDetail>> GetCommentsByUserId(int id);
        IDataResult<List<CommentDetail>> GetCommentDetail();
        IDataResult<List<CommentDetail>> GetCommentDetails(int id);
    }
}
