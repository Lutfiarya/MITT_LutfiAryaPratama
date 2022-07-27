using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MITT.Models;

namespace MITT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private MasterContext _context = new MasterContext();

        [HttpPost("register")]
        public IActionResult Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User.Add(user);
            _context.SaveChanges();

            return View("success");

        }


        /* Function login */

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody] AuthenticateModel model)
        //{
        //    var user = _userService.Authenticate(model.Username, model.Password);

        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    // return basic user info and authentication token
        //    return Ok(new
        //    {
        //        Id = user.Id,
        //        Username = user.Username,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Token = tokenString
        //    });
        //}

        [HttpGet]
        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var user = _context.User.FirstOrDefault(x => x.username == username);

            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        [HttpPut("{username}")]
        public IActionResult Update(string username, [FromBody] User user)
        {
            if (user.username != username)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            var s = _context.User.FirstOrDefault(x => x.username == username);

            if (s == null)
            {
                return NotFound();
            }

            _context.User.Remove(s);
            _context.SaveChanges();
            return Ok(s);
        }

    }
}
