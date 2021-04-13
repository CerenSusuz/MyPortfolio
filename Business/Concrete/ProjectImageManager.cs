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
    public class ProjectImageManager : IProjectImageService
    {
        IProjectImageDAL _projectImageDAL;

        public ProjectImageManager(IProjectImageDAL projectImageDAL)
        {
            _projectImageDAL = projectImageDAL;
        }

        [CacheRemoveAspect("IProjectImageService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProjectImageValidator))]
        public IResult Add(IFormFile file, ProjectImage projectImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(projectImage.ProjectId));
            if (result != null)
            {
                return result;
            }
            projectImage.ImagePath = FileHelper.Add(file);
            _projectImageDAL.Add(projectImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProjectImageService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(ProjectImage projectImage)
        {
            FileHelper.Delete(projectImage.ImagePath);
            _projectImageDAL.Delete(projectImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProjectImageService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProjectImageValidator))]
        public IResult Update(IFormFile file, ProjectImage projectImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(projectImage.ProjectId));
            if (result != null)
            {
                return result;
            }
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _projectImageDAL.Get(c => c.Id == projectImage.Id).ImagePath;
            projectImage.ImagePath = FileHelper.Update(oldPath, file);
            projectImage.Date = DateTime.Now;
            _projectImageDAL.Update(projectImage);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<ProjectImage> Get(int id)
        {
            return new SuccessDataResult<ProjectImage>(_projectImageDAL.Get(i => i.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<ProjectImage>> GetAll()
        {
            return new SuccessDataResult<List<ProjectImage>>(_projectImageDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<ProjectImage>> GetImagesByProjectId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfProjectImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<ProjectImage>>(result.Message);
            }

            return new SuccessDataResult<List<ProjectImage>>(CheckIfProjectImageNull(id).Data);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int projectId)
        {
            var projectImageCount = _projectImageDAL.GetAll(p => p.ProjectId == projectId).Count;
            if (projectImageCount >= 15)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<List<ProjectImage>> CheckIfProjectImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";
                var result = _projectImageDAL.GetAll(p => p.ProjectId == id).Any();
                if (!result)
                {
                    List<ProjectImage> projectImage = new List<ProjectImage>();
                    projectImage.Add(new ProjectImage
                    { 
                        ProjectId = id, 
                        ImagePath = path, 
                        Date = DateTime.Now });
                    return new SuccessDataResult<List<ProjectImage>>(projectImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProjectImage>>(exception.Message);
            }
            return new SuccessDataResult<List<ProjectImage>>(_projectImageDAL.GetAll(p => p.ProjectId == id));
        }


    }
}




