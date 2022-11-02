using ECom.Application.Repositories;
using ECom.Domain.Entities;
using ECom.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistance.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
