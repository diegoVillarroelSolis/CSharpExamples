using System;

namespace Actio.Common.Events
{
  public class ActivityCreated : IAunthenticatedEvent
  {
    public Guid UserID { get; set;}
    public string Category { get;}
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedAt { get; }

    protected ActivityCreated(){}
    public ActivityCreated(Guid userId, string category, string name, string description, DateTime createdAt)
    {
        UserID = userId;
        Category = category;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }
  }
}