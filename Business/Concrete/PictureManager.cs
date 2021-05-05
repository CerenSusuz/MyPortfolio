using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class PictureManager : IPictureService
    {
        IPictureDAL _pictureDAL;
        public PictureManager(IPictureDAL pictureDAL)
        {
            _pictureDAL = pictureDAL;
        }

        [CacheRemoveAspect("IPictureService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(IFormFile file, Picture picture)
        {
            picture.ImagePath = FileHelper.Add(file);
            _pictureDAL.Add(picture);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IPictureService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Picture picture)
        {
            FileHelper.Delete(picture.ImagePath);
            _pictureDAL.Delete(picture);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IPictureService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(IFormFile file, Picture picture)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _pictureDAL.Get(p => p.Id == picture.Id).ImagePath;
            picture.ImagePath = FileHelper.Update(oldPath, file);
            _pictureDAL.Update(picture);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<Picture> Get(int id)
        {
            return new SuccessDataResult<Picture>(_pictureDAL.Get(i => i.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Picture>> GetAll()
        {
            return new SuccessDataResult<List<Picture>>(_pictureDAL.GetAll());
        }
    }
}
