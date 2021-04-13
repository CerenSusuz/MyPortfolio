using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogImageValidator : AbstractValidator<BlogImage>
    {
        public BlogImageValidator()
        {
            RuleFor(i => i.BlogId).NotNull();
        }
    }
}
