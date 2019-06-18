using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
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
    public class UserController : ControllerBase
    {
        private readonly IGetUserCommand _getUserCommand;
        private readonly IGetUsersCommand _getUsersCommand;
        private readonly IEditUserCommand _editUserCommand;
        private readonly IAddUserCommand _addUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly LoggedUser _loggedUser;

        public UserController(IGetUserCommand getUserCommand, IGetUsersCommand getUsersCommand, IEditUserCommand editUserCommand, IAddUserCommand addUserCommand, IDeleteUserCommand deleteUserCommand, LoggedUser loggedUser)
        {
            _getUsersCommand = getUsersCommand;
            _getUserCommand = getUserCommand;
            _editUserCommand = editUserCommand;
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _loggedUser = loggedUser;
        }

        // GET: api/User
        [LoggedIn("Administrator")]
        [HttpGet]
        public IActionResult Get([FromQuery] UserQuery query)
        {
            try
            {
                return Ok(_getUsersCommand.Execute(query));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            
        }

        // GET: api/User/5
        [LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getUserCommand.Execute(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

        }

        // POST: api/User
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] AddUserDto query)
        {
            try
            {
                _addUserCommand.Execute(query);
                return StatusCode(201, "Successfully added user.");
            }
            catch (EntityAlreadyExistsException)
            {
                return StatusCode(422, "User with that email already exists.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // PUT: api/User/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GetUserDto dto)
        {
            try
            {
                dto.Id = id;
                _editUserCommand.Execute(dto);
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
                _deleteUserCommand.Execute(id);
                return StatusCode(204, "Successfully deleted user.");
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
