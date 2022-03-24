using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class LikeRepository : BaseRepository<Like>
    {
        public LikeRepository(DataContext ctx) : base(ctx)
        {
        }

        public override async Task<Like> GetById<P>(P id)
        {
            return await _dbContext.Likes.Where(l=>l.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
