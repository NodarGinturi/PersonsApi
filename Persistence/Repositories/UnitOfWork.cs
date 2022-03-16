using Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public IPersonRepository PersonRepository => _serviceProvider.GetService<IPersonRepository>();

        public IConnectedPersonRepository ConnectedPersonRepository => _serviceProvider.GetService<IConnectedPersonRepository>();
    }
}
