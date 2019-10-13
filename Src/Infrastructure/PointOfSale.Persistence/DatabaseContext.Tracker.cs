using Microsoft.EntityFrameworkCore;
using Navz.StudentPortal.Infrastructure;
using PointOfSale.Domain.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSale.Persistence
{
    public partial class DatabaseContext
    {

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach( var entity in entities)
            {
                if(entity.State == EntityState.Added)
                {
                    ((Entity)entity.Entity).DateCreated = new MachineDateTime().Now;
                }

                ((Entity)entity.Entity).DateModified = new MachineDateTime().Now;
            }

        }
    }
}
