using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MITT.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MITT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private MasterContext _context = new MasterContext();
        // GET: api/<SkillController>
        [HttpGet]
        public List<Skill> GetAll()
        {
            return _context.Skill.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var skills = _context.Skill.FirstOrDefault(x => x.skillId == id);

            if (skills == null)
            {
                return NotFound();
            }

            return new ObjectResult(skills);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Skill.Add(skill);
            _context.SaveChanges();

            return View("success");

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Skill skill)
        {
            if (skill.skillId != id)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var skill = _context.Skill.FirstOrDefault(x => x.skillId == id);

            if (skill == null)
            {
                return NotFound();
            }

            _context.Skill.Remove(skill);
            _context.SaveChanges();
            return Ok(skill);
        }
    }
}
