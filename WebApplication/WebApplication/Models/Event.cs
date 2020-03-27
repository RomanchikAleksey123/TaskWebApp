using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Tittle { get; set; }

        [Required]
        [StringLength(60)]
        public string Topic { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TotalNumberParticipants { get; set; }

        public int CurrentNumberParticipants { get; set; }

        [ForeignKey(nameof(Organizer))]
        public Guid OrganizerId { get; set; }

        public Organizer Organizer { get; set; }

        public List<ParticipantEvent> ParticipantEvents { get; set; }

        public Event()
        {
            ParticipantEvents = new List<ParticipantEvent>();
            CurrentNumberParticipants = default;
        }

        public bool CanEnter()
        {
            return 0 < TotalNumberParticipants - CurrentNumberParticipants;
        }

        public int GetNumberAvailableApplications()
        {
            return TotalNumberParticipants - CurrentNumberParticipants;
        }
    }
}
