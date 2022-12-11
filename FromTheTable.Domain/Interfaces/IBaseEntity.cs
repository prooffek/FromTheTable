using FromTheTable.Domain.Enums;

namespace FromTheTable.Domain.Interfaces;

public interface IBaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public State State { get; set; }
}