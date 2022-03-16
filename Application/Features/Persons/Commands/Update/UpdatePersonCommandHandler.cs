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

namespace Application.Features.Persons.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWorkRepository.PersonRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, person, typeof(UpdatePersonCommand), typeof(Person));

            await _unitOfWorkRepository.PersonRepository.UpdateAsync(person);

            return Unit.Value;
        }
    }
}
