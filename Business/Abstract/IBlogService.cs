using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(Blog blog);
        IResult Delete(Blog blog);
        IResult Update(Blog blog);
        IDataResult<List<Blog>> GetAll();
        IDataResult<Blog> GetById(int id);
    }

}
