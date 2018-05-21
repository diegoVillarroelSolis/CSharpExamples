using System;

namespace Actio.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
         Guid UserID { get; set; }
    }
}