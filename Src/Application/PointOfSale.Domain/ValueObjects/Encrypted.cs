using PointOfSale.Common.Security;
using PointOfSale.Domain.Exceptions;
using PointOfSale.Domain.Infrastructure;
using System;
using System.Collections.Generic;

namespace PointOfSale.Domain.ValueObjects
{
    public class Encrypted : ValueObject
    {
        public Encrypted()
        {

        }

        public static Encrypted For(string PlainText)
        {
            var encrypted = new Encrypted();

            try
            {
                encrypted.Salt = PasswordHasher.GenerateSalt();
                encrypted.Hash = PasswordHasher.ComputeHash(PlainText, encrypted.Salt);
            }
            catch (Exception ex)
            {
                throw new EncryptedInvalidException(PlainText, ex);
            }

            return encrypted;
        }

        public byte[] Salt { get; private set; }
        public byte[] Hash { get; private set; }

        //public static implicit operator string(Encrypted encrypted)
        //{
        //    return encrypted.ToString();
        //}

        public static explicit operator Encrypted(string PlainText)
        {
            return For(PlainText);
        }

        public bool Verify(string password) => PasswordHasher.VerifyPassword(password, Salt, Hash);

        //public override string ToString()
        //{
        //    //return $"{Salt}\\{Hash}";
        //    return "Encrypted";
        //}

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Salt;
            yield return Hash;
        }
    }
}
