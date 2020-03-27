using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Models
{
    public class User : IdentityUser
    {
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Surname { get; set; }

        public Organizer Organizer { get; set; }

        public List<ParticipantEvent> ParticipantEvents { get; set; }

        public User()
        {
            ParticipantEvents = new List<ParticipantEvent>();
        }
    }
}
