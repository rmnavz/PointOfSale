namespace PointOfSale.Persistence
{
    public class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            var initializer = new DatabaseInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            //if (context.Accounts.Any())
            //{
                //return; // Db has been seeded
            //}

        }
    }
}
