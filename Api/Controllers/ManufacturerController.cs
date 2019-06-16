using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using BusinessLogic.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IGetManufacturerCommand _getManufacturerCommand;
        private readonly IGetManufacturersCommand _getManufacturersCommand;
        private readonly IAddManufacturerCommand _addManufacturerCommand;
        private readonly IEditManufacturerCommand _editManufacturerCommand;
        private readonly IDeleteManufacturerCommand _deleteManufacturerCommand;

        public ManufacturerController(IGetManufacturerCommand getManufacturerCommand, IGetManufacturersCommand getManufacturersCommand, IAddManufacturerCommand addManufacturerCommand, IEditManufacturerCommand editManufacturerCommand, IDeleteManufacturerCommand deleteManufacturerCommand)
        {
            _getManufacturerCommand = getManufacturerCommand;
            _getManufacturersCommand = getManufacturersCommand;
            _addManufacturerCommand = addManufacturerCommand;
            _editManufacturerCommand = editManufacturerCommand;
            _deleteManufacturerCommand = deleteManufacturerCommand;
        }


        // GET: api/Manufacturer
        [HttpGet]
        public IActionResult Get([FromQuery] ManufacturerQuery query)
        {
            try
            {
                return Ok(_getManufacturersCommand.Execute(query));
            }
            catch(EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/Manufacturer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getManufacturerCommand.Execute(id));
            }
            catch(EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Manufacturer
        [HttpPost]
        public IActionResult Post([FromBody] AddManufacturerDto dto)
        {
            try
            {
                _addManufacturerCommand.Execute(dto);
                return StatusCode(201, "Successfully added manufacturer.");
            }
            catch
            {
                return StatusCode(422, "An error has occured");
            }
        }

        // PUT: api/Manufacturer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GetManufacturerDto dto)
        {
            try
            {
                dto.Id = id;
                _editManufacturerCommand.Execute(dto);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(422);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteManufacturerCommand.Execute(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(422);
            }
        }

        [HttpGet("{id}/items")]
        public IActionResult Nesto(int id)
        {
            return Ok(id);
        }
    }
}
