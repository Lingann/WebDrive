using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using WebDrive.App_Start;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Entities;
using Contracts;
namespace WebDrive.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UserController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var users = _repository.User.GetAllUser();
            var user = _repository.User.GetUser() ;
            var _user = _repository.User.GetUserById(1);
            return new string[] {user.name};
        }

        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);

                if (user.id.Equals(Guid.Empty)){
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            try
            {
                if(user == null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                _repository.User.AddUser(user);
                return CreatedAtRoute("UserById", new { id = user.id }, user);
               
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside AddUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }


        }
    }
}