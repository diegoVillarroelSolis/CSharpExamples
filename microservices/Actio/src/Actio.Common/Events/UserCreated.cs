namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Name { get; }
        public string Email { get; }

        protected UserCreated(){}
        public UserCreated(string name, string email)
        {
            Email= email;
            Name = name;
        }
    }
}