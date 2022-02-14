using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.IConfiguration;

namespace ViveVolar.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserProfileController : BaseController
    {
        /* public UserProfileController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        } */
        private UserManager<IdentityUser> _userManager;

        public UserProfileController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        /* 
       public UserProfileController(UserManager<IdentityUser> userManager)
       {
           _userManager = userManager;
       } */

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName
            };
        }
    }
}