
using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(DataContext ctx) : base(ctx)
        {
        }

        public override async Task<Author> GetById<P>(P id)
        {
            return await _dbContext.Authors.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();

        }

        public async Task AddView(string authorId)
        {
            Author author = await GetById(authorId);
            author.Views++;
            await Update(author);
        }
    }
}
