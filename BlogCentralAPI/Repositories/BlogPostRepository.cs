using BlogCentralAPI.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralAPI.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>
    {
        public BlogPostRepository(DataContext ctx) : base(ctx)
        {
        }
        public override async Task<IEnumerable<BlogPost>> ListAll()
        {
            return await _dbContext.BlogPosts./*Include(b => b.Blog).*/ToArrayAsync();
        }
        public override async Task<BlogPost> GetById(int id)
        {
            return await _dbContext.BlogPosts./*Include(c => c.Blog).Where(b => b.Id == id).*/FirstOrDefaultAsync();
        }
    }
}
