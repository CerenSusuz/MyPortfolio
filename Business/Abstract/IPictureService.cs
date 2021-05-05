using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPictureService
    {
        IResult Add(IFormFile file, Picture picture);
        IResult Delete(Picture picture);
        IResult Update(IFormFile file, Picture picture);
        IDataResult<Picture> Get(int id);
        IDataResult<List<Picture>> GetAll();
    }
}
