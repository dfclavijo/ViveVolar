using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Dtos.Incoming;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.IConfiguration;

namespace ViveVolar.Api.Controllers.v1
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[ApiVersion("1.0")]
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


        //GetAll
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAll();
            return Ok(users);       
        }

        
        //GetById
       [HttpGet]
       [Route("GetUser", Name = "GetUser")]
       public async Task<IActionResult> GetUsersByID(int id)
        {
            var userid = await _unitOfWork.Users.GetById(id);
            return Ok(userid);
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userdto)
        {
            var _user = new User();
            _user.LastName = userdto.LastName;
            _user.FirstName = userdto.FirstName;
            _user.Email = userdto.Email;
            _user.DateOfBirth = userdto.DateOfBirth;
            _user.Phone = userdto.Phone;
            _user.Country = userdto.Country;
            _user.status = 1;

            await _unitOfWork.Users.Add(_user);
            await _unitOfWork.CompleteAsync();
            //return Ok(); //200
            return CreatedAtRoute("GetUser", new {id = _user.Id}, userdto); //Return 201
        }



    }
}