using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.IConfiguration;
using ViveVolar.Authentication.Configuration;
using ViveVolar.Authentication.Models.DTO.Incoming;
using ViveVolar.Authentication.Models.DTO.Outgoing;

namespace ViveVolar.Api.Controllers.v1
{
    public class AccountsController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        public AccountsController(IUnitOfWork unitOfWork,IMapper mapper, UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionMonitor) : base(unitOfWork,mapper)
        {
            _userManager = userManager;
            _jwtConfig = optionMonitor.CurrentValue;
        }

        //Register Action
        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest registrationdto)
        {
             //Check a Valid Model
             if(ModelState.IsValid)
             {
                //Email already Exist
                var userExist = await _userManager.FindByEmailAsync(registrationdto.Email);
                if (userExist != null)
                {
                    return BadRequest(new UserRegistrationResponse(){
                        Success = false,
                        Errors = new List<string>(){
                                "Email Alreagy in Use"
                        }
                    });
                }
                //Add a Customer User
                
                var newUser = new IdentityUser()
                {
                    Email = registrationdto.Email,
                    UserName = registrationdto.Email,
                    EmailConfirmed = true,  
                };
               

                var iscreated = await _userManager.CreateAsync(newUser,registrationdto.Password);
                await _userManager.AddToRoleAsync(newUser, "Admin");
                
                if(!iscreated.Succeeded) // Registration Fail
                {
                    return BadRequest(new UserRegistrationResponse()
                    {
                        Success = iscreated.Succeeded,
                        Errors = iscreated.Errors.Select(x=>x.Description).ToList()

                    });
                    
                }

                //Add user to DB
                var _user = new User();
                _user.LastName = registrationdto.LastName;
                _user.FirstName = registrationdto.FirstName;
                _user.Email = registrationdto.Email;
                _user.DateOfBirth = DateTime.UtcNow;  //registrationdto.DateOfBirth;
                _user.Phone = "";
                _user.Country = "";
                _user.status = 1;

                await _unitOfWork.Users.Add(_user);
                await _unitOfWork.CompleteAsync();

                // Generar Token
                var token = GenerateJwtToken(newUser);
                return Ok(new UserRegistrationResponse()
                {
                    Success = true,
                    Token = token
                });

             }   
             else
             {
                return BadRequest(new UserRegistrationResponse
                {
                    Success = false,
                    Errors = new List<string>(){
                        "Invalid Data"
                    }
                });
             }    
        }


        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            if(ModelState.IsValid)
            {
                var userExist = await _userManager.FindByEmailAsync(loginRequest.Email);

                if(userExist==null)
                {
                    return BadRequest(new UserLoginResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid Authentication"
                        }
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(userExist, loginRequest.Password);
                
                if(isCorrect)
                {
                    var jwtToken = GenerateJwtToken(userExist);
                    return Ok(new UserLoginResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    //Password is Wrong
                    return BadRequest(new UserLoginResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid Authentication"
                        }
                    });
                }

            }
            else
            {
                return BadRequest(new UserRegistrationResponse
                {
                    Success = false,
                    Errors = new List<string>(){
                        "Invalid Data"
                    }
                });
            }
        }  
        
        

        private string GenerateJwtToken(IdentityUser user)
        {
           //Responsible token creation 
           var jwtHandler = new JwtSecurityTokenHandler(); 

           //Get Security Key
           var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
           //TODO var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        

           var tokenDescriptor = new SecurityTokenDescriptor
           {
                     Subject = new ClaimsIdentity(new []
               {
                   new Claim("Id", user.Id),
                   new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                   new Claim(JwtRegisteredClaimNames.Email, user.Email),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               }),
               Expires = DateTime.UtcNow.AddDays(3),
               SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
               )
           };

           //Generate Token
           var token = jwtHandler.CreateToken(tokenDescriptor);

           var jwtToken = jwtHandler.WriteToken(token);
           return jwtToken;
        }
    }
}