using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EF.DALs
{
    public class EFCertificateImageDAL:EFEntityRepositoryBase<CertificateImage,PortfolioDbContext>, ICertificateImageDAL
    {
    }
}
