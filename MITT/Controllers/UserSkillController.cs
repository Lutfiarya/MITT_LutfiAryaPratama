using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MITT.Models;

namespace MITT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserSkillController : Controller
    {
        private MasterContext _context = new MasterContext();

        [HttpGet]
        public List<UserSkill> GetAll()
        {
            return _context.UserSkill.ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userskill = _context.UserSkill.FirstOrDefault(x => x.userSkillId == id);

            if (userskill == null)
            {
                return NotFound();
            }

            return new ObjectResult(userskill);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserSkill userSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserSkill.Add(userSkill);
            _context.SaveChanges();

            return View("success");

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserSkill userSkill)
        {
            if (userSkill.skillLevelId != id)
            {
                return BadRequest();
            }

            _context.Entry(userSkill).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var s = _context.UserSkill.FirstOrDefault(x => x.userSkillId == id);

            if (s == null)
            {
                return NotFound();
            }

            _context.UserSkill.Remove(s);
            _context.SaveChanges();
            return Ok(s);
        }
    }
}
