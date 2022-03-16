using Application.Features.Persons.Commands.Create;
using Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Commands.Create
{
    public class CreateConnectedPersonCommand : IRequest
    {
        public RelationType ConnectType { get; set; }
        public int ConnectedPersonId { get; set; }
        public CreatePersonCommand Person { get; set; }
    }
}
