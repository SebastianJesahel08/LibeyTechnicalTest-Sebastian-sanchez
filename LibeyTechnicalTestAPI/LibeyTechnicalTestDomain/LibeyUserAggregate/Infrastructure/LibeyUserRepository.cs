using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;

        public LibeyUserRepository(Context context)
        {
            _context = context;
        }

        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);

            if (row == null) return new LibeyUserResponse();

            return new LibeyUserResponse
            {
                DocumentNumber = row.DocumentNumber,
                Active = row.Active,
                Address = row.Address,
                DocumentTypeId = row.DocumentTypeId,
                Email = row.Email,
                FathersLastName = row.FathersLastName,
                MothersLastName = row.MothersLastName,
                Name = row.Name,
                Password = row.Password,
                Phone = row.Phone,
                UbigeoCode = row.UbigeoCode,
                RegionCode = "",
                ProvinceCode = ""
            };
        }

        public IEnumerable<LibeyUserResponse> List(string? search)
        {
            var query = _context.LibeyUsers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                query = query.Where(x =>
                    x.DocumentNumber.Contains(search) ||
                    x.Name.Contains(search) ||
                    x.FathersLastName.Contains(search) ||
                    x.MothersLastName.Contains(search) ||
                    x.Email.Contains(search));
            }

            return query
                .Select(x => new LibeyUserResponse
                {
                    DocumentNumber = x.DocumentNumber,
                    Active = x.Active,
                    Address = x.Address,
                    DocumentTypeId = x.DocumentTypeId,
                    Email = x.Email,
                    FathersLastName = x.FathersLastName,
                    MothersLastName = x.MothersLastName,
                    Name = x.Name,
                    Password = x.Password,
                    Phone = x.Phone,
                    UbigeoCode = x.UbigeoCode,
                    RegionCode = "",
                    ProvinceCode = ""
                })
                .ToList();
        }

        public void Update(LibeyUser libeyUser)
        {
            var current = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == libeyUser.DocumentNumber);
            if (current == null) return;

            current.DocumentTypeId = libeyUser.DocumentTypeId;
            current.Name = libeyUser.Name;
            current.FathersLastName = libeyUser.FathersLastName;
            current.MothersLastName = libeyUser.MothersLastName;
            current.Address = libeyUser.Address;
            current.UbigeoCode = libeyUser.UbigeoCode;
            current.Phone = libeyUser.Phone;
            current.Email = libeyUser.Email;
            current.Password = libeyUser.Password;

            _context.SaveChanges();
        }

        public void Delete(string documentNumber)
        {
            var current = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (current == null) return;

            _context.LibeyUsers.Remove(current);
            _context.SaveChanges();
        }
    }
}
