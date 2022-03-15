
using BlogCentralApp.Data;
using BlogCentralLib.Entities;

namespace BlogCentralApp.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>
    {
        public BlogPostRepository(DataContext ctx) : base(ctx)
        {
        }
    }
}
