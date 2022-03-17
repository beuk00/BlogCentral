using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(DataContext ctx) : base(ctx)
        {

        }
        public override Task<Comment> GetById<P>(P id)
        {
            throw new System.NotImplementedException();
        }
    }
}
