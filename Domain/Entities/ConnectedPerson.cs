using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ConnectedPerson : BaseEntity
    {
        public int Id { get; set; }
        public RelationType ConnectType { get; set; }
        public int ConnectedPersonId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
