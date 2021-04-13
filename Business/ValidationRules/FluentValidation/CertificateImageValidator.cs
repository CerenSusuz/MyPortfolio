using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CertificateImageValidator : AbstractValidator<CertificateImage>
    {
        public CertificateImageValidator()
        {
            RuleFor(i => i.CertificateId).NotNull();
        }
    }
}
