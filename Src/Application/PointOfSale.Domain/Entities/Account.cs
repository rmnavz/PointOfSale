using PointOfSale.Domain.ValueObjects;
using System;

namespace PointOfSale.Domain.Entities
{
    public class Account
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public Encrypted Password { get; set; }
    }
}
