using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IResult Add(Project project);
        IResult Delete(Project project);
        IResult Update(Project project);
        IDataResult<List<Project>> GetAll();
        IDataResult<Project> GetById(int id);
    }

}
