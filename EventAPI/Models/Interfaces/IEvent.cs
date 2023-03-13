namespace EventAPI.Models.Interfaces
{
    public interface IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
    }
}
