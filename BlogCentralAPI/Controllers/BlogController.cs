using BlogCentralAPI.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogCentralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerCrudBase<Blog, BlogRepository>
    {
        public BlogController(BlogRepository r) : base(r)
        {
        }
        public override async Task<IActionResult> Add([FromBody] Blog entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Blog item = await repository.Create(entity);
            if (item == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetById", new { id = entity.Id }, entity);
        }

        public override async Task<IActionResult> Update([FromRoute] int id, [FromBody] Blog entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            Blog e = await repository.Update(entity);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }
    }
}
