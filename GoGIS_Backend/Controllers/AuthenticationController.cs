using GoGIS_Model.ViewModel;
using GoGIS_Services.AuthService;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;

namespace GoGIS_Backend.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthService _authService = new AuthService();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/user/signup")]
        public IHttpActionResult Signup(UserDetails userDetails)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var check = _authService.CheckEmailExists(userDetails.email);

                if (check != null)
                {
                    return BadRequest("Email already Exists!!");
                }

                var user = _authService.Signup(userDetails.name, userDetails.email, userDetails.password);

                if (user == null)
                {
                    return BadRequest("Invalid username or password");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/user/login")]
        public IHttpActionResult Login(UserDetails model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }

                var user = _authService.Login(model.email, model.password);

                if (user == null)
                {
                    return BadRequest("Invalid username or password");
                }

                var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.name));
                identity.AddClaim(new Claim("Email", user.email));

                var properties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "userName", user.name },
                    { "userEmail", user.email }
                });

                var ticket = new AuthenticationTicket(identity, properties);

                var accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);

                var response = new
                {
                    access_token = accessToken,
                    userName = user.name,
                    userEmail = user.email
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        //[Authorize]
        [Route("api/user/user_details")]
        public IHttpActionResult AllUser()
        {
            try
            {
                var user = _authService.AllUserDetails();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        //[Authorize]
        [Route("api/user/user_details/{id}")]
        public IHttpActionResult AllUserById(int id)
        {
            try
            {
                var user = _authService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize]
        [Route("api/user/user_details")]
        public IHttpActionResult UpdateUser(UserDetails userDetails)
        {
            try
            {
                var user = _authService.UpdateUserDetails(userDetails);
                if (user == null)
                {
                    return BadRequest("Something went wrong!!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/user/user_details/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                var user = _authService.DeleteUserDetails(id);
                if (user == null)
                {
                    return BadRequest("Something went wrong!!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
