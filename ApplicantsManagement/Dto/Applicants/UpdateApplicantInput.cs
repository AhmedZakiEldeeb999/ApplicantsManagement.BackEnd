using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantsManagement.Dto.Applicants
{
    public class UpdateApplicantInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
    public class UpdateApplicantInputValidator : AbstractValidator<UpdateApplicantInput>
    {
        public UpdateApplicantInputValidator()
        {
            RuleFor(a => a.Id).NotEqual(0).WithMessage("Id cant be 0");

            RuleFor(a => a.Name).NotEmpty().WithMessage("Name cant be empty")
           .NotNull().WithMessage("Name cant be null")
           .MinimumLength(5).WithMessage("Name Minimum Length 5 char ");

            RuleFor(a => a.FamilyName).NotEmpty().WithMessage("FamilyName cant be empty")
            .NotNull().WithMessage("FamilyName cant be null")
            .MinimumLength(5).WithMessage("FamilyName Minimum Length 5 char ");

            RuleFor(a => a.Address).NotEmpty().WithMessage("Address cant be empty")
            .NotNull().WithMessage("Address cant be null")
            .MinimumLength(10).WithMessage("Address Minimum Length 10 char ");

            RuleFor(a => a.Age).NotEqual(0).WithMessage("Age cant be 0")
           .LessThanOrEqualTo(60).WithMessage("Age must be between 20 and 60")
           .GreaterThanOrEqualTo(20).WithMessage("Age must be between 20 and 60");

            RuleFor(s => s.EMailAdress).NotEmpty().WithMessage("Email address is required")
            .NotNull().WithMessage("Email address is required")
            .EmailAddress().WithMessage("A valid email is required");

        }
    }
}
