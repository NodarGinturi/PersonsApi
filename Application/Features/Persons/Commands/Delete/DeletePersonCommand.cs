using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
