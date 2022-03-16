using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Commands.Create
{
    public class CreateConnectedPersonCommandHandler : IRequestHandler<CreateConnectedPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public CreateConnectedPersonCommandHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateConnectedPersonCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateConnectedPersonCommandValidator(_unitOfWorkRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            //Added new Person
            var person = _mapper.Map<Person>(request.Person);
            var newPerson = await _unitOfWorkRepository.PersonRepository.AddAsync(person);

            //Added ConnectedPerson
            var @event = _mapper.Map<ConnectedPerson>(request);
            @event.PersonId = newPerson.Id;
            await _unitOfWorkRepository.ConnectedPersonRepository.AddAsync(@event);

            return Unit.Value;
        }
    }
}
