using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;

        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            return _repository.FindResponse(documentNumber);
        }

        public IEnumerable<LibeyUserResponse> List(string? search)
        {
            return _repository.List(search);
        }

        public void Create(UserUpdateorCreateCommand command)
        {
            var user = new LibeyUser(
                command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password
            );

            _repository.Create(user);
        }

        public void Update(string documentNumber, UserUpdateorCreateCommand command)
        {
            var user = new LibeyUser(
                documentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password
            );

            _repository.Update(user);
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }
    }
}
