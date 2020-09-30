using FluentValidation;
using MAQSTestSite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAQSTestSite.Validators
{
    public class SaveEmployeeResourceValidator : AbstractValidator<SaveEmployeeResource>
    {
        public SaveEmployeeResourceValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(m => m.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(m => m.Address)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(150);

            RuleFor(m => m.DepartmentId)
               .NotEmpty()
               .WithMessage("'Department ID' must not be 0.");
        }
    }
}
