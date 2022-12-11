using FromTheTable.Domain.Enums;
using FromTheTable.Domain.Interfaces;

namespace FromTheTable.Domain.Entities.Base;

public abstract class BaseEntity : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public State State { get; set; }

    protected BaseEntity()
    {
        CreatedOn = DateTime.Now;
        ModifiedOn = CreatedOn;
        State = State.Active;
    }
}