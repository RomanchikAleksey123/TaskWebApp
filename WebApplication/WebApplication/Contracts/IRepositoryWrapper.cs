namespace WebApplication.Contracts
{
    public interface IRepositoryWrapper
    {
        IEventRepository Event { get; set; }

        IOrganizerRepository Organizer { get; set; }

        IParticipantEventRepository ParticipantEvent { get; set; }

        void Save();
    }
}