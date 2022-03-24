using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class VisitorRepository : BaseRepository<Visitor>
    {
        public VisitorRepository(DataContext ctx) : base(ctx)
        {
        }

        public override Task<Visitor> GetById<P>(P id)
        {
            throw new System.NotImplementedException();
        }
    }
}
