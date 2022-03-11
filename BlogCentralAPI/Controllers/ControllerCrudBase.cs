using BlogCentralLib.Interfaces;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogCentralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerCrudBase<T, R> : ControllerBase where T : class where R : IRepository<T>
    {
        protected R repository;

        public ControllerCrudBase(R r)
        {
            repository = r;
        }


        // read
        [HttpGet]
        public virtual async Task<IActionResult> ListAll()
        {
            return Ok(await repository.ListAll());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return Ok(await repository.GetById(id));
        }

        // delete
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var entity = await repository.DeleteById(id);
            if (entity == null)
            {
                return NotFound(); // 404
            }

            return Ok(entity);
        }

        // create
        [HttpPost]
        public virtual  Task<IActionResult> Add([FromBody] T entity)
        {
            throw new System.NotImplementedException();
        }

        // update
        [HttpPut("{id}")]
        public virtual  Task<IActionResult> Update([FromRoute] int id, [FromBody] T entity)
        {
            throw  new  System.NotImplementedException();
        }
    }
}
