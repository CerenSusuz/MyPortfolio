using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICertificateService
    {
        IResult Add(Certificate certificate);
        IResult Delete(Certificate certificate);
        IResult Update(Certificate certificate);
        IDataResult<List<Certificate>> GetAll();
        IDataResult<Certificate> GetById(int id);
    }

}
