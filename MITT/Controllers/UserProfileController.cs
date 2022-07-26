using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MITT.Models;

namespace MITT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : Controller
    {
        private MasterContext _context = new MasterContext();

        [HttpGet]
        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }


        [HttpPost("Register")]
        public IActionResult Create([FromBody] UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserProfile.Add(userProfile);
            _context.SaveChanges();

            return View("success");
        }

        [HttpPut("Register/{Id}")]
        public IActionResult Update([FromBody] UserProfile userProfile, int Id)
        {
            if (userProfile.userProfileId != Id)
            {
                return BadRequest();
            }

            _context.Entry(userProfile).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

    }
}
