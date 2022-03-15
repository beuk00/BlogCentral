
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
            return await _dbContext.BlogPosts.Include(b => b.Comments).Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Like(int id)
        {
            
            BlogPost blogPost = await GetById(id);
            blogPost.Likes++;
            await Update(blogPost);
        }
        public async Task Unlike(int id)
        {

            BlogPost blogPost = await GetById(id);
            blogPost.Likes =blogPost.Likes-1;
            await Update(blogPost);
        }
    }
}
