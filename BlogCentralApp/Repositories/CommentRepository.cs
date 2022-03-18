using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(DataContext ctx) : base(ctx)
        {

        }
        public override async Task<Comment> GetById<P>(P id)
        {
            return await _dbContext.Comments.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
