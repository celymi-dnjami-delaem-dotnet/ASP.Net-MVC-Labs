using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.MVC.Models;
using REST.MVC.Repository;

namespace REST.MVC.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>Get all users</summary>
        /// <response code="200">Get all users</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserModel>>> GetUsers() => await _userRepository.GetUsers();
        
        /// <summary>Get exact user</summary>
        /// <param name="id" example="123">User's id</param>
        /// <response code="200">User was found</response>
        /// <response code="404">User was not found</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        /// <summary>Add user</summary>
        /// <param name="user">User's model</param>
        /// <response code="200">User was added</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] UserModel user)
        {
            await _userRepository.AddUser(user);

            return Ok("User added");
        }
        
        /// <summary>Update exact user</summary>
        /// <param name="user">User's model</param>
        /// <response code="200">User was updated</response>
        /// <response code="400">Invalid parameters in request</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel user)
        {
            var existingUser = await _userRepository.GetUser(user.Id);
            if (existingUser == null)
            {
                return BadRequest("User not updated");
            }
            
            await _userRepository.UpdateUser(user);

            return Ok("User updated");
        }
        
        /// <summary>Remove exact user</summary>
        /// <param name="id" example="123">User's id</param>
        /// <response code="200">User was removed</response>
        /// <response code="404">User was not removed</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var existingUser = await _userRepository.GetUser(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }
            
            await _userRepository.RemoveUser(id);

            return Ok("UserDeleted");
        }
    }
}