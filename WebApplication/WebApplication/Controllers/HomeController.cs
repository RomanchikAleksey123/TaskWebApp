using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Contracts;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager, IRepositoryWrapper repositoryWrapper)
        {
            _userManager = userManager;
            _repositoryWrapper = repositoryWrapper;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var events = _repositoryWrapper.Event.FindByCondition(x => x.Organizer.UserId != userId).ToList();

            var eventWithoutParticipant = new List<Event>();
            foreach (var eEvent in events)
            {
                if (!_repositoryWrapper.ParticipantEvent.FindAll().ToList().Exists((x => x.UserId == userId && x.EventId == eEvent.Id)))
                    eventWithoutParticipant.Add(eEvent);
            }

            var eventsUserParticipate = _repositoryWrapper.Event.FindAll().ToList().
                FindAll(x => x.ParticipantEvents.Exists(t => t.UserId == userId));

            var myEvents = _repositoryWrapper.Event.FindAll().ToList().
                FindAll(x => x.Organizer.UserId == userId);

            return View(new HomeViewModel
            {
                Events = eventWithoutParticipant,
                EventsWhichIParticipate = eventsUserParticipate,
                MyEvents = myEvents
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
