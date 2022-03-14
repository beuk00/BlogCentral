
using BlogCentralApp.Data;
using BlogCentralLib.Entities;

namespace BlogCentralApp.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(DataContext ctx) : base(ctx)
        {
        }
    }
}
