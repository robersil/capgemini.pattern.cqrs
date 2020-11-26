using CQRS.Application.Command.Request;
using CQRS.Application.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public EmployeeController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var request = new EmployeeGetRequest() { Id = id };
                return Ok(_mediatr.Send(request));
            }
            catch(Exception ex)
            {
                return BadRequest("Erro ao buscar o funcionário. " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeCreateCommand command)
        {
            try
            {
                return Created("/api/Employees", _mediatr.Send(command));
            }
            catch(Exception ex)
            {
                return BadRequest("Erro ao salvar os dados do funcionário. " + ex.ToString());
            }
        }
    }
}