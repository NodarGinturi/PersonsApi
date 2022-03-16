using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Queries
{
    public class GetConnectedPersonsListQueryHandler : IRequestHandler<GetConnectedPersonsListQuery, List<ConnectedPersonsListVM>>
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;

        public GetConnectedPersonsListQueryHandler(IUnitOfWork unitOfWorkRepository, IMapper mapper)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<List<ConnectedPersonsListVM>> Handle(GetConnectedPersonsListQuery request, CancellationToken cancellationToken)
        {
            var connectedPersonsList = (await _unitOfWorkRepository.ConnectedPersonRepository.ListAllAsync()).Where(x => x.PersonId == 1).OrderBy(x => x.Id);
            return _mapper.Map<List<ConnectedPersonsListVM>>(connectedPersonsList);
        }
    }
}
