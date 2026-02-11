using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Catalogs
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepository _repository;

        public DocumentTypeController(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repository.GetAll();
            return Ok(list);
        }
    }
}
