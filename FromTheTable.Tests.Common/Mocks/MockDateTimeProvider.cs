using FromTheTable.Application.Common.Interfaces;

namespace FromTheTable.Tests.Common.Mocks;

public class MockDateTimeProvider : IDateTimeProvider
{
    private static IDateTimeProvider? _instance;


    private MockDateTimeProvider() { }

    public static IDateTimeProvider GetInstance()
    {
        if (_instance == null)
        {
            _instance = new MockDateTimeProvider();
        }

        return _instance;
    }

    public DateTime Now { get; set; } = DateTime.Now;
}