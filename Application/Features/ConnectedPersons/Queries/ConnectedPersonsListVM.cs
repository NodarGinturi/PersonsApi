using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConnectedPersons.Queries
{
    public class ConnectedPersonsListVM
    {
        public int Id { get; set; }
        public RelationType ConnectType { get; set; }
        public int ConnectedPersonId { get; set; }
        public int PersonId { get; set; }
    }
}
