using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }
        IConnectedPersonRepository ConnectedPersonRepository { get; }
    }
}
