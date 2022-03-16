using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands.Update
{
    public class UpdatePersonCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Pid { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
    }
}
