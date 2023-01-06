using Newtonsoft.Json;

namespace Gymmer.Infrastructure.Persistence.Models.Base;

public abstract class NoSqlEntity
{
    [JsonProperty(PropertyName = "id")] public string Id { get; set; } = string.Empty;
}