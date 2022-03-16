using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {

        }

        public Task<bool> IsPidUnique(string pid)
        {
            var match = _dbContext.Persons.Any(x => x.Pid == pid);
            return Task.FromResult(match);
        }
    }
}
