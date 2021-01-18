using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseThing.Data.Respository;
using WiseThing.Portal.Business;



namespace WiseThingPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;
        public UserController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        
        [HttpGet("{userName}/{passWord}")]
        public async Task<UserDTO> GetLoginUserDetails(string userName, string passWord)
        {
            return await _userHandler.GetUserByLogin(userName, passWord);
        }

       
        [HttpGet("{userid}")]
        public async Task<UserDTO> GetUserById(int userid)
        {
            
           return await _userHandler.GetUserById(userid);
           
        }

        [HttpGet("{userName}")]
        public async Task<bool> CheckUserNameAvialable(string userName)
        {

            return await _userHandler.IsUserNameAlreadyExsist(userName);

        }

        
        [HttpPost]
        public async Task<StatusCodeResult> AddEditUser([FromBody] UserDTO user)
        {
            if (user != null)
            {
                await _userHandler.AddEditUser(user);
                return Ok();
            }
            else
            {
                return NotFound();
                
            }
                    
        }

        
    }
}
