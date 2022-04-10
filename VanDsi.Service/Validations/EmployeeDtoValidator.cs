using FluentValidation;
using VanDsi.Core.DTOs;

namespace VanDsi.Service.Validations
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0 ");
            RuleFor(x => x.NameLastName).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
                .WithMessage("{propertyName} is required");
            RuleFor(x => x.FatherName).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
                .WithMessage("{propertyName} is required");
        }
    }
}
