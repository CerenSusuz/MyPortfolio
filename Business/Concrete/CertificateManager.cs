using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CertificateManager : ICertificateService
    {
        ICertificateDAL _certificateDAL;
        public CertificateManager(ICertificateDAL certificateDAL)
        {
            _certificateDAL = certificateDAL;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICertificateService.Get")]
        public IResult Add(Certificate certificate)
        {
            _certificateDAL.Add(certificate);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICertificateService.Get")]
        public IResult Delete(Certificate certificate)
        {
            _certificateDAL.Delete(certificate);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICertificateService.Get")]
        public IResult Update(Certificate certificate)
        {
            _certificateDAL.Update(certificate);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Certificate>> GetAll()
        {
            return new SuccessDataResult<List<Certificate>>(_certificateDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Certificate> GetById(int id)
        {
            return new SuccessDataResult<Certificate>(_certificateDAL.Get(c => c.Id == id));
        }

    }
}