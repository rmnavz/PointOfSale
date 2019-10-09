using Microsoft.EntityFrameworkCore;
using PointOfSale.Persistence.Infrastructure;

namespace PointOfSale.Persistence
{
    public class DatabaseContextFactory : DesignTimeDbContextFactoryBase<DatabaseContext>
    {
        protected override DatabaseContext CreateNewInstance(DbContextOptions<DatabaseContext> options)
        {
            return new DatabaseContext(options);
        }
    }
}
