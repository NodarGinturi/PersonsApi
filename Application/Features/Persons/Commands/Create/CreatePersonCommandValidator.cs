using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Create
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public CreatePersonCommandValidator(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;


            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName  is not valid");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("LastName  is not valid");

            RuleFor(x => x.Pid)
                .MinimumLength(1)
                .MaximumLength(11)
                .NotEmpty()
                .WithMessage("Pid is not valid");

            RuleFor(x => x.CityId)
                .GreaterThanOrEqualTo(1)
                .NotEmpty()
                .WithMessage("City  is not valid");

            RuleFor(x => (int)x.Gender)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(2)
                .WithMessage("Gender is not valid");

            RuleFor(x => x.Phone)
                .MinimumLength(4)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage("Phone is not valid");

            RuleFor(x => x.BirthDate.Year)
                .GreaterThanOrEqualTo(18)
                .NotEmpty()
                .WithMessage("BirthDate Year is not valid");

            RuleFor(x => x)
                .MustAsync(PersonPidUnique)
                .WithMessage("Pid already exist");
        }

        private async Task<bool> PersonPidUnique(CreatePersonCommand createPersonCommand, CancellationToken token)
        {
            return !(await _unitOfWorkRepository.PersonRepository.IsPidUnique(createPersonCommand.Pid));
        }
    }
}
