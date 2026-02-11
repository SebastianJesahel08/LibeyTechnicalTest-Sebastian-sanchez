using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;

        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<DocumentType> GetAll()
        {
            return _context.DocumentTypes
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
