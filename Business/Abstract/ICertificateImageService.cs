using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
      public interface ICertificateImageService
    {
        IResult Add(IFormFile file, CertificateImage image);
        IResult Delete(CertificateImage image);
        IResult Update(IFormFile file, CertificateImage image);
        IDataResult<CertificateImage> Get(int id);
        IDataResult<List<CertificateImage>> GetAll();
        IDataResult<List<CertificateImage>> GetImagesByCertificateId(int id);
    }
}
