using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using WebApplication.Contracts;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly  UserManager<User> _userManager;

        public EventController(AppDbContext appDbContext, UserManager<User> userManager, IRepositoryWrapper repositoryWrapper)
        {
            _userManager = userManager;
            _repositoryWrapper = repositoryWrapper;
        }

        public IActionResult Delete(Guid eventId)
        {
            var eventForDelete = _repositoryWrapper.Event.FindEventById(eventId);
            if (eventForDelete == null) return RedirectToAction("Index", "Home");
            _repositoryWrapper.Event.Delete(eventForDelete);
            _repositoryWrapper.Save();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEvent)
        {
     
            var userId = _userManager.GetUserId(HttpContext.User);

            var organizer = _repositoryWrapper.Organizer.GetOrganizerByUserId(userId);

            var @event = new Event()
            {
                Tittle = addEvent.Tittle,
                Topic = addEvent.Topic,
                Description = addEvent.Description,
                Address = addEvent.Address,
                Date = addEvent.Date,
                TotalNumberParticipants = addEvent.TotalNumberParticipants,
                OrganizerId = organizer.Id,
                Organizer = organizer
            };

            _repositoryWrapper.Event.Create(@event);
            _repositoryWrapper.Save();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var eventForEdit = _repositoryWrapper.Event.FindEventById(id);

            return View(eventForEdit);
        }

        [HttpPost]
        public IActionResult Edit(Event editEvent)
        {
            _repositoryWrapper.Event.Update(editEvent);
            _repositoryWrapper.Save();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Participate(Guid eventId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _repositoryWrapper.Organizer.GetOrganizerByUserId(userId).User;
            var currentEvent = _repositoryWrapper.Event.FindEventById(eventId);
            var participantEvent = new ParticipantEvent {Event = currentEvent, EventId = currentEvent.Id, UserId = user.Id, User = user};
            currentEvent.ParticipantEvents.Add(participantEvent);
            currentEvent.CurrentNumberParticipants++;
            _repositoryWrapper.Event.Update(currentEvent);
            _repositoryWrapper.Save();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExitEvent(Guid eventId)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var currentEvent = _repositoryWrapper.Event.FindEventById(eventId);
            var participantEvents = _repositoryWrapper.ParticipantEvent.FindAll()
                .First(x => x.EventId == eventId && x.UserId == userId);
            _repositoryWrapper.ParticipantEvent.Delete(participantEvents);
            currentEvent.CurrentNumberParticipants--;
            _repositoryWrapper.Event.Update(currentEvent);
            _repositoryWrapper.Save();

            return RedirectToAction("Index", "Home");
        }
    }
} 