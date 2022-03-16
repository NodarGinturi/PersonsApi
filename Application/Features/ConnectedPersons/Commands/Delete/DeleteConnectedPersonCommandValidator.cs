using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Commands.Delete
{
    public class DeleteConnectedPersonCommandValidator : AbstractValidator<DeleteConnectedPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public DeleteConnectedPersonCommandValidator(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;

            RuleFor(x => x.ConnectedPersonId)
                .NotEmpty()
                .WithMessage("ConnectedPersonId  is not valid");
        }
    }
}
