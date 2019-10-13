using System;

namespace PointOfSale.Domain.Infrastructure
{
    public abstract class Entity
    {
        public Guid ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
