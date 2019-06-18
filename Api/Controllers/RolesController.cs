using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using BusinessLogic.Queries;
using EfCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRoleCommand _getRoleCommand;
        private readonly IGetRolesCommand _getRolesCommand;
        private readonly IAddRoleCommand _addRoleCommand;
        private readonly IEditRoleCommand _editRoleCommand;
        private readonly IDeleteRoleCommand _deleteRoleCommand;
        private readonly LoggedUser _loggedUser;

        public RolesController(IGetRoleCommand getRoleCommand, IGetRolesCommand getRolesCommand, IAddRoleCommand addRoleCommand, IEditRoleCommand editRoleCommand, IDeleteRoleCommand deleteRoleCommand, LoggedUser loggedUser)
        {
            _getRoleCommand = getRoleCommand;
            _getRolesCommand = getRolesCommand;
            _addRoleCommand = addRoleCommand;
            _editRoleCommand = editRoleCommand;
            _deleteRoleCommand = deleteRoleCommand;
            _loggedUser = loggedUser;
        }


        // GET: api/Roles
        [LoggedIn("Administrator")]
        [HttpGet]
        public IActionResult Get([FromQuery]RoleQuery query)
        {
            try
            {
                return Ok(_getRolesCommand.Execute(query));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/Roles/5
        [LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getRoleCommand.Execute(id));
            }
            catch(EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Roles
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] AddRoleDto dto)
        {
            try
            {
                _addRoleCommand.Execute(dto);
                return StatusCode(201, "Successfully added a new role.");
            }
            catch
            {
                return StatusCode(422, "Error while trying to add a new role.");
            }
        }

        // PUT: api/Roles/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddRoleDto dto)
        {
            try
            {
                dto.Id = id;
                _editRoleCommand.Execute(dto);
                return StatusCode(204, "Successfully updated user.");
            }
            catch
            {
                return StatusCode(422, "Error while trying to update user.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteRoleCommand.Execute(id);
                return StatusCode(204, "Successfully deleted role.");
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
