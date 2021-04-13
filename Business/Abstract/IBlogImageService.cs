using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBlogImageService
    {
        IResult Add(IFormFile file, BlogImage image);
        IResult Delete(BlogImage image);
        IResult Update(IFormFile file, BlogImage image);
        IDataResult<BlogImage> Get(int id);
        IDataResult<List<BlogImage>> GetAll();
        IDataResult<List<BlogImage>> GetImagesByBlogId(int id);
    }

}
