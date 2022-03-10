using BlogCentralAPI.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogCentralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerCrudBase<BlogPost, BlogPostRepository>
    {
        public BlogPostController(BlogPostRepository r) : base(r)
        {

        }
        [HttpPost]
        public override async Task<IActionResult> Add([FromBody] BlogPost entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            BlogPost item = await repository.Create(entity);
            if (item == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetById", new { id = entity.Id }, entity);
        }

        
        [HttpPut("{id}")]
        public override async Task<IActionResult> Update([FromRoute] int id, [FromBody] BlogPost entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            BlogPost e = await repository.Update(entity);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }
    }
}
