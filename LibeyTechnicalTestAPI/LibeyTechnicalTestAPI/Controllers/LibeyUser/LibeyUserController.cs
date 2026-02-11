using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : ControllerBase
    {
        private readonly ILibeyUserAggregate _aggregate;

        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        
        //GET
        [HttpGet]
        public IActionResult List([FromQuery] string? search)
        {
            var rows = _aggregate.List(search);
            return Ok(rows);
        }

        //GET
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }

        //POST
        [HttpPost]
        public IActionResult Create([FromBody] UserUpdateorCreateCommand command)
        {
            _aggregate.Create(command);
            return Ok(true);
        }

        //PUT
        [HttpPut("{documentNumber}")]
        public IActionResult Update(string documentNumber, [FromBody] UserUpdateorCreateCommand command)
        {
            _aggregate.Update(documentNumber, command);
            return Ok(true);
        }

        //DELETE
        [HttpDelete("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            _aggregate.Delete(documentNumber);
            return Ok(true);
        }
    }
}
