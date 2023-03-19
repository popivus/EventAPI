namespace EventAPI.Models.Interfaces
{
    public interface IUser
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
    }
}
