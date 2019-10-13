using PointOfSale.Persistence;
using ReactiveUI;
using Splat;

namespace PointOfSale.Application.Infrastructure
{
    public abstract class BaseCommand : ReactiveObject
    {

        protected DatabaseContext context = Locator.Current.GetService<DatabaseContext>();
    }
}
