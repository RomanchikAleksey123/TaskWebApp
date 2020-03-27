using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class HomeViewModel
    {
        public List<Event> MyEvents { get; set; }

        public List<Event> Events { get; set; }

        public List<Event> EventsWhichIParticipate { get; set; }
    }
}
