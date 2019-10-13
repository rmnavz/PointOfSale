using FluentValidation;
using System.Linq;

namespace PointOfSale.Application.Interfaces
{
    public interface IValidatable<T>
    {
        T Validator { get; set; }
    }
}
