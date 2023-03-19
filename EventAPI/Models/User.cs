using EventAPI.Models.Interfaces;

namespace EventAPI.Models
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
    }
}
