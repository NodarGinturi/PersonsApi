using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Commands.Delete
{
    public class DeleteConnectedPersonCommand : IRequest
    {
        public int ConnectedPersonId { get; set; }
    }
}
