using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Contracts;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public override IQueryable<Event> FindAll()
        {
            return this.RepositoryContext.Set<Event>().Include(x => x.Organizer.User).Include(t =>t.ParticipantEvents);
        }
        public override IQueryable<Event> FindByCondition(Expression<Func<Event, bool>> expression)
        {
            return this.RepositoryContext.Set<Event>().Include(x => x.Organizer.User).Where(expression).AsNoTracking();
        }

        public Event FindEventById(Guid id)
        {
            return this.RepositoryContext.Set<Event>().Include(x => x.Organizer.User).First(x => x.Id == id);
        }
    }
    
}
