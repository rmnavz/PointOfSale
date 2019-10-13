using PointOfSale.Domain.Entities;
using PointOfSale.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Persistence
{
    public class DatabaseInitializer
    {
        private readonly Dictionary<int, Account> Accounts = new Dictionary<int, Account>();
        public static void Initialize(DatabaseContext context)
        {
            var initializer = new DatabaseInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Accounts.Any())
            {
                return; // Db has been seeded
            }

            SeedAccounts(context);

        }

        public void SeedAccounts(DatabaseContext context)
        {

            Accounts.Add(1, new Account {
                Username = "Admin",
                Password = (Encrypted)"!P@ssw0rd"
            });

            foreach (var account in Accounts.Values)
            {
                context.Accounts.Add(account);
            }

            context.SaveChanges();
        }
    }
}
