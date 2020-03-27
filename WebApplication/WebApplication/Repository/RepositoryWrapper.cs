using WebApplication.Contracts;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _repoContext;
        private IEventRepository _event;
        private IOrganizerRepository _organizer;
        private IParticipantEventRepository _participantEvent;


        public IEventRepository Event
        {
            get { return _event ??= new EventRepository(_repoContext); }
            set => throw new System.NotImplementedException();
        }

        public IOrganizerRepository Organizer
        {
            get { return _organizer ??= new OrganizerRepository(_repoContext); }
            set => throw new System.NotImplementedException();
        }

        public IParticipantEventRepository ParticipantEvent
        {
            get { return _participantEvent ??= new ParticipantEventRepository(_repoContext); }
            set => throw new System.NotImplementedException();
        }


        public RepositoryWrapper(AppDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
