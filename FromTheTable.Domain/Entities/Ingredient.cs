using FromTheTable.Domain.Entities.Base;
using FromTheTable.Domain.Enums;

namespace FromTheTable.Domain.Entities;

public class Ingredient : BaseEntity
{
    public string? Name { get; set; }

    public Ingredient(string name)
    {
        CreatedOn = DateTime.UtcNow;
        ModifiedOn = CreatedOn;
        Name = name;
        State = State.Active;
    }
}