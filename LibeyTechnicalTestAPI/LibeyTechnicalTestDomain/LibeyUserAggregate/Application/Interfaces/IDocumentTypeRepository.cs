using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Collections.Generic;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IDocumentTypeRepository
    {
        IEnumerable<DocumentType> GetAll();
    }
}
