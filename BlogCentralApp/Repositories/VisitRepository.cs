using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class VisitRepository : BaseRepository<Visit>
    {
        public VisitRepository(DataContext ctx) : base(ctx)
        {
        }

        public override Task<Visit> GetById<P>(P id)
        {
            throw new System.NotImplementedException();
        }
    }
}
