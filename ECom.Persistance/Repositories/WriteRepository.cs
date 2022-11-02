using ECom.Application.Repositories;
using ECom.Domain.Entities.Common;
using ECom.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly EComDbContext _context;

        public WriteRepository(EComDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public bool Add(T Model)
        {
            EntityEntry<T> entityEntry = Table.Add(Model);
            return entityEntry.State == EntityState.Added;

        }
        public bool AddRange(List<T> datas)
        {
            Table.AddRange(datas);
            return true;
        }

        public bool Remove(T model)
        {
            Table.Remove(model);
            return true;
        }

        public async Task<bool> Remove(string id)
        {
        T model= await Table.FirstOrDefaultAsync(option => option.Id == Guid.Parse(id));
            
            return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
