using FromTheTable.Application.Common.Interfaces;

namespace FromTheTable.Application.Common.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}