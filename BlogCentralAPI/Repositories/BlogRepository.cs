using BlogCentralAPI.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralAPI.Repositories
{
    public class BlogRepository : BaseRepository<Blog>
    {
        public BlogRepository(DataContext ctx) : base(ctx)
        {
        }

        public override  async Task<Blog> GetById(int id)
        {
            return await _dbContext.Blogs.Where(b=> b.Id == id).FirstOrDefaultAsync(); 
        }
    }
}
