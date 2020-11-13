using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WDT2020_a3.Helpers;

/*
    This Authentication controller is outside the repository, as such it is the only open
    url source.

    Given the correct username and password stored in user-secrets the controller will
    return a session Jwt Token to be appened to all headers in the clent HTTP requests

    This design was insipired by a Jason Watmore exercise
    https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api#running-angular
 */

namespace WDT2020_a3.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthSecurity _authDetails;
        private readonly AuthLogin _loginDetails;


        public AuthController(IOptions<AuthSecurity> authDetails, IOptions<AuthLogin> loginDetails)
        {
            _authDetails = authDetails.Value ?? throw new ArgumentException(nameof(AuthSecurity));
            _loginDetails = loginDetails.Value ?? throw new ArgumentException(nameof(AuthLogin));
        }

        [HttpPost("login")]
        public ActionResult GetToken([FromBody]AuthLogin model)
        {
            /*HARDCODE MODE
             * 
             ******************************************************************************/

            var securityKey = "long_ass_security_key_2019_02_07$smesk.in";
            var userName = "username";
            var password = "password";


            /*HIDDEN KEYS MODE
             * 
             ******************************************************************************/

            //var securityKey = _authDetails.AuthKey;
            //var userName = model.UserName;
            //var password = model.Password;


            //security key -- hardcoded if user-secrets is not implemented
            //username = username , password = password

            //If username and pasword does not match
            if (!(_loginDetails.UserName.Equals(userName)
                && _loginDetails.Password.Equals(password)))
            {
                return BadRequest(new { message = "Login details given were incorrect" });
            }


            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //create a token
            var token = new JwtSecurityToken(
                    issuer: "smesk.in",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );
            //This authentication model is returned as such the client can store it into session
            return Ok(new User
            {
                Username = model.UserName,
                Password = model.Password,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
