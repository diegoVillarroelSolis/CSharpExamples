namespace Actio.Common.Events
{
    public class UserAunthenticated : IEvent
    {
        public string Email { get; }
        protected UserAunthenticated(){}
        public UserAunthenticated(string email)
        {
            Email = email;
        }
    }
}