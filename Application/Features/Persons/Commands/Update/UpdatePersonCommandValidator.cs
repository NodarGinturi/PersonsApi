using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Update
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public UpdatePersonCommandValidator(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("სახელი არ არის ვალიდური");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("გვარი არ არის ვალიდური");

            RuleFor(x => x.Pid)
                .MinimumLength(1)
                .MaximumLength(11)
                .NotEmpty()
                .WithMessage("პირადი ნომერი არ არის ვალიდური");

            RuleFor(x => x.CityId)
                .GreaterThanOrEqualTo(1)
                .NotEmpty()
                .WithMessage("ქალაქი არ არის ვალიდური");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage("სქესი არ არის ვალიდური");

            RuleFor(x => x.Phone)
                .MinimumLength(4)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage("ტელეფონის ნომერი არ არის ვალიდური");

            RuleFor(x => x.BirthDate.Year)
                .GreaterThanOrEqualTo(18)
                .NotEmpty()
                .WithMessage("დაბადების თარიღი არ არის ვალიდური");
        }
    }
}
