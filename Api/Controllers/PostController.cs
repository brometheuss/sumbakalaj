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
    public class PostController : ControllerBase
    {
        private readonly IGetPostsCommand _getPostsCommand;
        private readonly IGetPostCommand _getPostCommand;
        private readonly IAddPostCommand _addPostsCommand;
        private readonly IEditPostCommand _editPostsCommand;
        private readonly IDeletePostCommand _deletePostsCommand;
        private readonly LoggedUser _loggedUser;

        public PostController(IGetPostsCommand getPostsCommand, IGetPostCommand getPostCommand, IAddPostCommand addPostCommand, IEditPostCommand editPostCommand, IDeletePostCommand deletePostCommand, LoggedUser loggedUser)
        {
            _getPostsCommand = getPostsCommand;
            _getPostCommand = getPostCommand;
            _addPostsCommand = addPostCommand;
            _editPostsCommand = editPostCommand;
            _deletePostsCommand = deletePostCommand;
            _loggedUser = loggedUser;
        }


        // GET: api/Post
        [LoggedIn]
        [HttpGet]
        public IActionResult Get([FromQuery] PostQuery dto)
        {
            try
            {
                return Ok(_getPostsCommand.Execute(dto));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            
        }

        // GET: api/Post/5
        [LoggedIn]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getPostCommand.Execute(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Post
        [LoggedIn("User")]
        [HttpPost]
        public IActionResult Post([FromBody] AddPostDto dto)
        {
            try
            {
                _addPostsCommand.Execute(dto);
                return StatusCode(201, "Successfully created.");
            }
            catch
            {
                return StatusCode(422, "An error has occurred.");
            }
        }

        // PUT: api/Post/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddPostDto dto)
        {
            try
            {
                dto.Id = id;
                _editPostsCommand.Execute(dto);
                return StatusCode(204, "Successfully edited.");
            }
            catch
            {
                return StatusCode(422, "An error has occurred.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deletePostsCommand.Execute(id);
                return StatusCode(204, "Successfully deleted post.");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
