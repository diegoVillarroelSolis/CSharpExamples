using System.Threading.Tasks;

namespace Actio.Common.Events
{
    public interface IEventHanlder<T> where T : IEvent
    {
         Task HandleAsync(T @event);
    }
}