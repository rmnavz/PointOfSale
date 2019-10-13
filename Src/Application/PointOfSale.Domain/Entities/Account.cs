using PointOfSale.Domain.Infrastructure;
using PointOfSale.Domain.ValueObjects;
using System;

namespace PointOfSale.Domain.Entities
{
    public class Account : Entity
    {
        public string Username { get; set; }
        public Encrypted Password { get; set; }
    }
}
