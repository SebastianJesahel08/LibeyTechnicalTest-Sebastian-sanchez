using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);

        IEnumerable<LibeyUserResponse> List(string? search);

        void Create(UserUpdateorCreateCommand command);

        void Update(string documentNumber, UserUpdateorCreateCommand command);

        void Delete(string documentNumber);
    }
}
