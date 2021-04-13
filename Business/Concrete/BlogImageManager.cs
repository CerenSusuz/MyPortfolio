using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BlogImageManager : IBlogImageService
    {
        IBlogImageDAL _blogImageDAL;

        public BlogImageManager(IBlogImageDAL blogImageDAL)
        {
            _blogImageDAL = blogImageDAL;
        }

        [CacheRemoveAspect("IBlogImageService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BlogImageValidator))]
        public IResult Add(IFormFile file, BlogImage blogImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(blogImage.BlogId));
            if (result != null)
            {
                return result;
            }
            blogImage.ImagePath = FileHelper.Add(file);
            _blogImageDAL.Add(blogImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IBlogImageService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BlogImageValidator))]
        public IResult Delete(BlogImage blogImage)
        {
            FileHelper.Delete(blogImage.ImagePath);
            _blogImageDAL.Delete(blogImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IBlogImageService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BlogImageValidator))]
        public IResult Update(IFormFile file, BlogImage blogImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(blogImage.BlogId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _blogImageDAL.Get(p => p.Id == blogImage.Id).ImagePath;
            blogImage.ImagePath = FileHelper.Update(oldPath, file);
            blogImage.Date = DateTime.Now;
            _blogImageDAL.Update(blogImage);
            return new SuccessResult();
        }

        [CacheAspect]
        [ValidationAspect(typeof(BlogImageValidator))]
        public IDataResult<BlogImage> Get(int id)
        {
            return new SuccessDataResult<BlogImage>(_blogImageDAL.Get(i => i.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<BlogImage>> GetAll()
        {
            return new SuccessDataResult<List<BlogImage>>(_blogImageDAL.GetAll());
        }

        [CacheAspect]
        [ValidationAspect(typeof(BlogImageValidator))]
        public IDataResult<List<BlogImage>> GetImagesByBlogId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfBlogImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<BlogImage>>(result.Message);
            }

            return new SuccessDataResult<List<BlogImage>>(CheckIfBlogImageNull(id).Data);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int blogId)
        {
            var blogImageCount = _blogImageDAL.GetAll(b => b.BlogId == blogId).Count;
            if (blogImageCount >= 3)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<List<BlogImage>> CheckIfBlogImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";
                var result = _blogImageDAL.GetAll(b => b.BlogId == id).Any();
                if (!result)
                {
                    List<BlogImage> blogImage = new List<BlogImage>();
                    blogImage.Add(new BlogImage { BlogId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<BlogImage>>(blogImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<BlogImage>>(exception.Message);
            }
            return new SuccessDataResult<List<BlogImage>>(_blogImageDAL.GetAll(b => b.BlogId == id));
        }


    }
}




