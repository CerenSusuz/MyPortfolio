using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDAL _blogDAL;
        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBlogService.Get")]
        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog)
        {
            _blogDAL.Add(blog);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBlogService.Get")]
        public IResult Delete(Blog blog)
        {
            _blogDAL.Delete(blog);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BlogValidator))]
        [CacheRemoveAspect("IBlogService.Get")]
        public IResult Update(Blog blog)
        {
            _blogDAL.Update(blog);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDAL.Get(b => b.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Blog>> GetBySubjectId(int id)
        {
            return new SuccessDataResult<List<Blog>>(_blogDAL.GetAll(b => b.SubjectId == id));
        }
    }
}