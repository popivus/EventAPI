using EventAPI.Models.Interfaces;

namespace EventAPI.Models
{
    public class Event : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }

        public Event(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, Guid imageId, Guid spaceId)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ImageId = imageId;
            SpaceId = spaceId;
        }
    }
}
