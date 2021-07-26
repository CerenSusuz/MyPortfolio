using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISubjectService
    {
        IResult Add(Subject subject);
        IResult Delete(Subject subject);
        IResult Update(Subject subject);
        IDataResult<List<Subject>> GetAll();
        IDataResult<Subject> GetById(int id);
    }
}
