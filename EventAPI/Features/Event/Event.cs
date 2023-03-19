using EventAPI.Features.Ticket;
using Swashbuckle.AspNetCore.Annotations;

namespace EventAPI.Features.Event
{
    /// <summary>
    /// Модель мероприятия
    /// </summary>
    public class Event : IEvent
    {
        /// <summary>
        /// Id мероприятия
        /// </summary>
        [SwaggerSchema(Description = "Id мероприятия")]
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование мероприятия
        /// </summary>
        [SwaggerSchema(Description = "Наименование мероприятия")]
        public string Name { get; set; }


        /// <summary>
        /// Описание мероприятия
        /// </summary>
        [SwaggerSchema(Description = "Описание мероприятия")]
        public string Description { get; set; }


        /// <summary>
        /// Начало мероприятия 
        /// </summary>
        [SwaggerSchema(Description = "Начало мероприятия")]
        public DateTime StartDateTime { get; set; }


        /// <summary>
        /// Окончание мероприятия 
        /// </summary>
        [SwaggerSchema(Description = "Окончание мероприятия")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Id картинки мероприятия 
        /// </summary>
        [SwaggerSchema(Description = "Id картинки мероприятия")]
        public Guid ImageId { get; set; }

        /// <summary>
        /// Id места проведения мероприятия 
        /// </summary>
        [SwaggerSchema(Description = "Id места проведения мероприятия")]
        public Guid SpaceId { get; set; }

        /// <summary>
        /// Билеты данного мероприятия 
        /// </summary>
        [SwaggerSchema(Description = "Билеты данного мероприятия")]
        public IEnumerable<ITicket> Tickets { get; set; } = new List<ITicket>();

        /// <summary>
        /// Есть ли ещё билеты на данное мероприятие 
        /// </summary>
        [SwaggerSchema(Description = "Есть ли ещё билеты на данное мероприятие")]
        public bool Availability { get; set; }

        public Event(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, Guid imageId, Guid spaceId, IEnumerable<ITicket> tickets, bool availability)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ImageId = imageId;
            SpaceId = spaceId;
            Tickets = tickets;
            Availability = availability;
        }
    }
}
