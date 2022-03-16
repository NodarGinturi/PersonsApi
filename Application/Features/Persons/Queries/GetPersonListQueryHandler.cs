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
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, List<PersonListVM>>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonListVM>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var personList = (await _unitOfWorkRepository.PersonRepository.ListAllAsync());
            var a = _mapper.Map<List<PersonListVM>>(personList);
            return a;
        }
    }
}
