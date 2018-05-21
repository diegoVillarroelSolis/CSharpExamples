namespace Actio.Common.Commands
{
    public class AunthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}