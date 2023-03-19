using Swashbuckle.AspNetCore.Annotations;

namespace EventAPI.Features.Ticket
{
    /// <summary>
    /// Билет на мероприятие
    /// </summary>
    public class Ticket : ITicket
    {
        /// <summary>
        /// Id билета 
        /// </summary>
        [SwaggerSchema(Description = "Id билета")]
        public Guid Id { get; set; }

        /// <summary>
        /// Id пользователя, обладающего данным билетом 
        /// </summary>
        [SwaggerSchema(Description = "Id пользователя, обладающего данным билетом")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Место 
        /// </summary>
        [SwaggerSchema(Description = "Место")]
        public string Place { get; set; }

        public Ticket(Guid id, Guid userId, string place)
        {
            Id = id;
            UserId = userId;
            Place = place;
        }
    }
}
