
using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>
    {
        public BlogPostRepository(DataContext ctx) : base(ctx)
        {

        }

        public override async Task<BlogPost> GetById<P>(P id)
        {
            return await _dbContext.BlogPosts.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
