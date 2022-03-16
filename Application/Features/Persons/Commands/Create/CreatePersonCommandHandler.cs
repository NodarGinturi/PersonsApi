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

namespace Application.Features.Persons.Commands.Create
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePersonCommandValidator(_unitOfWorkRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Person>(request);

            @event = await _unitOfWorkRepository.PersonRepository.AddAsync(@event);

            return @event.Id;
        }
    }
}
