using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public DeletePersonCommandValidator(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;

            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("შეიყვანეთ სწორი პერსონის აიდი");
        }
    }
}
