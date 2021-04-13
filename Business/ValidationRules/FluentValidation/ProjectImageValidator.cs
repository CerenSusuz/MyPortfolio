using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProjectImageValidator : AbstractValidator<ProjectImage>
    {
        public ProjectImageValidator()
        {
            RuleFor(i => i.ProjectId).NotNull();
        }
    }
}
