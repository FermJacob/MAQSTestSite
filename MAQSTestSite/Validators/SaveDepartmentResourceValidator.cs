using FluentValidation;
using MAQSTestSite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAQSTestSite.Validators
{
    public class SaveDepartmentResourceValidator : AbstractValidator<SaveDepartmentResource>
    {
        public SaveDepartmentResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
