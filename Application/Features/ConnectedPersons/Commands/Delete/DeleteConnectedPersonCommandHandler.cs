using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Commands.Delete
{
    public class DeleteConnectedPersonCommandHandler : IRequestHandler<DeleteConnectedPersonCommand>
    {

        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public DeleteConnectedPersonCommandHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteConnectedPersonCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteConnectedPersonCommandValidator(_unitOfWorkRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var connectedPerson = await _unitOfWorkRepository.ConnectedPersonRepository.GetByIdAsync(request.ConnectedPersonId);
            await _unitOfWorkRepository.ConnectedPersonRepository.DeleteAsync(connectedPerson);

            return Unit.Value;
        }
    }
}
