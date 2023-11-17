using DapperData.Models;
using DapperData.Repositary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDN_Company.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositary _userRepositary;
        public UserController(IUserRepositary userRepositary)
        {
            _userRepositary = userRepositary;
        }
        // GET: api/<UserController>
        /// <summary>
        /// endpoint for getting users list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepositary.GetAllUsers();
            return Ok(users);
        }

        // GET api/<UserController>/5
        /// <summary>
        /// Endpoint for getting user info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var _id = int.Parse(id);
            var users = await _userRepositary.GetUserById(_id);
            if (users is null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // POST api/<UserController>
        /// <summary>
        /// Endpoint for adding user info into database
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var result = await _userRepositary.AddUser(users);
            if (!result)
            {
                return BadRequest("Could not Save Data");
            }
            return Ok();
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Endpoint for update the user info intotabase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Users newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var user = _userRepositary.GetUserById(id);
            if (user is null)
                return NotFound();
            newUser.Id = id;
            var result = await _userRepositary.UpdateUser(newUser);
            if (!result)
            {
                return BadRequest("Could not Save Data");
            }
            return Ok();
        }

        // DELETE api/<UserController>/5
        /// <summary>
        /// Endpoint for delete the user info into database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var _id = int.Parse(id);
            var user = _userRepositary.GetUserById(_id);
            if (user is null)
                return NotFound();
            var result = await _userRepositary.DeleteUser(_id);
            if (!result)
            {
                return BadRequest("Could not Save Data");
            }
            return Ok();
        }
    }
}
