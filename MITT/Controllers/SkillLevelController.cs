using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MITT.Models;

namespace MITT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SkillLevelController : Controller
    {
        private MasterContext _context = new MasterContext();
        [HttpGet]
        public List<SkillLevel> GetAll()
        {
            return _context.SkillLevel.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var skillLevel = _context.SkillLevel.FirstOrDefault(x => x.skillLevelId == id);

            if (skillLevel == null)
            {
                return NotFound();
            }

            return new ObjectResult(skillLevel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SkillLevel skillLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SkillLevel.Add(skillLevel);
            _context.SaveChanges();

            return View("success");

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SkillLevel skillLevel)
        {
            if (skillLevel.skillLevelId != id)
            {
                return BadRequest();
            }

            _context.Entry(skillLevel).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var s = _context.SkillLevel.FirstOrDefault(x => x.skillLevelId == id);

            if (s == null)
            {
                return NotFound();
            }

            _context.SkillLevel.Remove(s);
            _context.SaveChanges();
            return Ok(s);
        }
    }
}
