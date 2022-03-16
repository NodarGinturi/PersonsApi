using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Commands.Create
{
    public class CreateConnectedPersonCommandValidator : AbstractValidator<CreateConnectedPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public CreateConnectedPersonCommandValidator(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;


            RuleFor(x => x.ConnectedPersonId)
                .NotEmpty()
                .WithMessage("ConnectedPersonId  is not valid");

            RuleFor(x => (int)x.ConnectType)
                .NotEmpty()
                .WithMessage("ConnectedPersonId  is not valid");

        }
    }
}
