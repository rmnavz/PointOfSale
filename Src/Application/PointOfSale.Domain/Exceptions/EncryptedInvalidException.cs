using System;

namespace PointOfSale.Domain.Exceptions
{
    public class EncryptedInvalidException : Exception
    {
        public EncryptedInvalidException(string PlainText, Exception ex)
            : base($"Encryption \"{PlainText[0]}{PlainText.Replace(PlainText.Substring(0), "*****")}\" is invalid.", ex)
        {

        }
    }
}