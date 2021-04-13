using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectImageService
    {
        IResult Add(IFormFile file, ProjectImage image);
        IResult Delete(ProjectImage image);
        IResult Update(IFormFile file, ProjectImage image);
        IDataResult<ProjectImage> Get(int id);
        IDataResult<List<ProjectImage>> GetAll();
        IDataResult<List<ProjectImage>> GetImagesByProjectId(int id);
    }

}
