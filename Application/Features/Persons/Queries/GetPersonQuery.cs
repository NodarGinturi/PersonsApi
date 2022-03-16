using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Persons.Queries
{
    public class GetPersonQuery : IRequest<PersonListVM>
    {
        public int Id { get; set; }
    }
}
