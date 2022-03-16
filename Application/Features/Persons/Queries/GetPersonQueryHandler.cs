using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Persons.Queries
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonListVM>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<PersonListVM> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var @person = await _unitOfWorkRepository.PersonRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<PersonListVM>(person);

            var connectedPersons = await _unitOfWorkRepository.ConnectedPersonRepository.ListAllAsync(@person.Id);
            return result;

        }
    }
}
