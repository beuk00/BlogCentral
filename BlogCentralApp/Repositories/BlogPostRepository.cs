
using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>
    {
        public BlogPostRepository(DataContext ctx) : base(ctx)
        {
        }

    }
}
