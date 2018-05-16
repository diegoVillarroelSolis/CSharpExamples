using System;

namespace Actio.Common.Events
{
    public interface IAunthenticatedEvent : IEvent
    {
        Guid UserID { get; set; }         
    }
}