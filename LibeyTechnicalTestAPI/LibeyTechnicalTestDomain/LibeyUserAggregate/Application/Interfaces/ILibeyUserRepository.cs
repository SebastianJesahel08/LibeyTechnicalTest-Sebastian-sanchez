using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);

        IEnumerable<LibeyUserResponse> List(string? search);

        void Create(LibeyUser libeyUser);

        void Update(LibeyUser libeyUser);

        void Delete(string documentNumber);
    }
}
