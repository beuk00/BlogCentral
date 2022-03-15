
using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(DataContext ctx) : base(ctx)
        {
        }

        public override Task<Author> GetById<P>(P id)
        {
            throw new System.NotImplementedException();
        }
    }
}
