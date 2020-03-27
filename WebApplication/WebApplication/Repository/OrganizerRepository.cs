using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Contracts;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Repository
{
    public class OrganizerRepository : RepositoryBase<Organizer>, IOrganizerRepository
    {
        void IRepositoryBase<Organizer>.Create(Organizer entity)
        {
            throw new NotImplementedException();
        }

        void IRepositoryBase<Organizer>.Delete(Organizer entity)
        {
            throw new NotImplementedException();
        }

        public Organizer GetOrganizerByUserId(string id)
        {
            return this.RepositoryContext.Set<Organizer>().Include(x => x.User).First(x => x.UserId == id);
        }


        IQueryable<Organizer> IRepositoryBase<Organizer>.FindAll()
        {
            throw new NotImplementedException();
        }

        IQueryable<Organizer> IRepositoryBase<Organizer>.FindByCondition(Expression<Func<Organizer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        void IRepositoryBase<Organizer>.Update(Organizer entity)
        {
            throw new NotImplementedException();
        }

        public OrganizerRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
