using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string Pid { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<ConnectedPerson> ConnectedPersons { get; set; }
    }
}
