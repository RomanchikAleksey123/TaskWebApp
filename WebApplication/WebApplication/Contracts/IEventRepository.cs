using System;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Contracts
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Event FindEventById(Guid id);

    }
}