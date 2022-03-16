using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCommandHanler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public DeletePersonCommandHanler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePersonCommandValidator(_unitOfWorkRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var person = await _unitOfWorkRepository.PersonRepository.GetByIdAsync(request.Id);

            await _unitOfWorkRepository.PersonRepository.DeleteAsync(person);

            return Unit.Value;
        }
    }
}
