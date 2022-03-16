using Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Create
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string Pid { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
    }
}
