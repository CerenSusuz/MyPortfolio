using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDAL _projectDAL;
        public ProjectManager(IProjectDAL projectDAL)
        {
            _projectDAL = projectDAL;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProjectService.Get")]
        [ValidationAspect(typeof(ProjectValidator))]
        public IResult Add(Project project)
        {
            _projectDAL.Add(project);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProjectService.Get")]
        public IResult Delete(Project project)
        {
            _projectDAL.Delete(project);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProjectValidator))]
        [CacheRemoveAspect("IProjectService.Get")]
        public IResult Update(Project project)
        {
            _projectDAL.Update(project);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Project> GetById(int id)
        {
            return new SuccessDataResult<Project>(_projectDAL.Get(c => c.Id == id));
        }

    }
}