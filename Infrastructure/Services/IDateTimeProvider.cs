using Application.Interfaces;

namespace Infrastructure.Services; 

public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}