using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Contracts
{
    public interface IOrganizerRepository : IRepositoryBase<Organizer>
    {
        Organizer GetOrganizerByUserId(string id);
    }
}