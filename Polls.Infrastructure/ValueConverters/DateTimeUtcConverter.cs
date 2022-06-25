using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Polls.Infrastructure.ValueConverters;

public class DateTimeUtcConverter : ValueConverter<DateTime, DateTime>
{
    public DateTimeUtcConverter() : base(
        v => v.SetKindUtc(),
        v => v)
    {
    }
}