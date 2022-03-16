using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Queries
{
    public class GetConnectedPersonsListQuery : IRequest<List<ConnectedPersonsListVM>>
    {
        public GetConnectedPersonsListQuery(int id)
        {

        }
    }
}
