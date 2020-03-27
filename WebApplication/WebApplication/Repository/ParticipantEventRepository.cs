using WebApplication.Contracts;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Repository
{
    public class ParticipantEventRepository : RepositoryBase<ParticipantEvent>, IParticipantEventRepository
    {
        public ParticipantEventRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }

    }
}
