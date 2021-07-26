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
    public class CertificateImageManager : ICertificateImageService
    {
        readonly ICertificateImageDAL _certificateImageDAL;

        public CertificateImageManager(ICertificateImageDAL certificateImageDAL)
        {
            _certificateImageDAL = certificateImageDAL;
        }

        [CacheRemoveAspect("ICertificateImageService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(IFormFile file, CertificateImage certificateImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(certificateImage.CertificateId));
            if (result != null)
            {
                return result;
            }
            certificateImage.ImagePath = FileHelper.Add(file);
            _certificateImageDAL.Add(certificateImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICertificateImageService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(CertificateImage certificateImage)
        {
            FileHelper.Delete(certificateImage.ImagePath);
            _certificateImageDAL.Delete(certificateImage);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICertificateImageService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(IFormFile file, CertificateImage certificateImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(certificateImage.CertificateId));
            if (result != null)
            {
                return result;
            }
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +_certificateImageDAL.Get(c => c.Id == certificateImage.Id).ImagePath;
            certificateImage.ImagePath = FileHelper.Update(oldPath, file);
            _certificateImageDAL.Update(certificateImage);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<CertificateImage> Get(int id)
        {
            return new SuccessDataResult<CertificateImage>(_certificateImageDAL.Get(i => i.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CertificateImage>> GetAll()
        {
            return new SuccessDataResult<List<CertificateImage>>(_certificateImageDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CertificateImage>> GetImagesByCertificateId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCertificateImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CertificateImage>>(result.Message);
            }

            return new SuccessDataResult<List<CertificateImage>>(CheckIfCertificateImageNull(id).Data);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int certificateId)
        {
            var certificateImageCount = _certificateImageDAL.GetAll(c => c.CertificateId == certificateId).Count;
            if (certificateImageCount >= 1)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<List<CertificateImage>> CheckIfCertificateImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";
                var result = _certificateImageDAL.GetAll(c => c.CertificateId == id).Any();
                if (!result)
                {
                    List<CertificateImage> certificateImage = new List<CertificateImage>
                    {
                        new CertificateImage
                        {
                            CertificateId = id,
                            ImagePath = path
                        }
                    };
                    return new SuccessDataResult<List<CertificateImage>>(certificateImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CertificateImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CertificateImage>>(_certificateImageDAL.GetAll(c => c.CertificateId == id));
        }


    }
}




