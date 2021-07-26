using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SubjectManager : ISubjectService
    {
        readonly ISubjectDAL _subjectDAL;
        public SubjectManager(ISubjectDAL subjectDAL)
        {
            _subjectDAL = subjectDAL;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ISubjectService.Get")]
        public IResult Add(Subject subject)
        {
            _subjectDAL.Add(subject);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ISubjectService.Get")]
        public IResult Delete(Subject subject)
        {
            _subjectDAL.Delete(subject);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ISubjectService.Get")]
        public IResult Update(Subject subject)
        {
            _subjectDAL.Update(subject);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Subject>> GetAll()
        {
            return new SuccessDataResult<List<Subject>>(_subjectDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Subject> GetById(int id)
        {
            return new SuccessDataResult<Subject>(_subjectDAL.Get(s => s.Id == id));
        }

    }
}
