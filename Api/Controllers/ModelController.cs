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
    public class ModelController : ControllerBase
    {
        private readonly IGetModelCommand _getModelCommand;
        private readonly IGetModelsCommand _getModelsCommand;
        private readonly IAddModelCommand _addModelCommand;
        private readonly IEditModelCommand _editModelCommand;
        private readonly IDeleteModelCommand _deleteModelCommand;

        public ModelController(IGetModelCommand getModelCommand, IGetModelsCommand getModelsCommand, IAddModelCommand addModelCommand, IEditModelCommand editModelCommand, IDeleteModelCommand deleteModelCommand)
        {
            _getModelCommand = getModelCommand;
            _getModelsCommand = getModelsCommand;
            _addModelCommand = addModelCommand;
            _editModelCommand = editModelCommand;
            _deleteModelCommand = deleteModelCommand;
        }


        // GET: api/Model
        [HttpGet]
        public IActionResult Get([FromQuery] ModelQuery dto)
        {
            try
            {
                return Ok(_getModelsCommand.Execute(dto));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }

        // GET: api/Model/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getModelCommand.Execute(id));
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e);
            }
        }

        // POST: api/Model
        [HttpPost]
        public IActionResult Post([FromBody] AddModelDto dto)
        {
            try
            {
                _addModelCommand.Execute(dto);
                return StatusCode(201, "Successfully added model.");
            }
            catch(EntityAlreadyExistsException)
            {
                return StatusCode(422, "An error has occured.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // PUT: api/Model/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GetModelDto dto)
        {
            try
            {
                dto.Id = id;
                _editModelCommand.Execute(dto);
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
                _deleteModelCommand.Execute(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
