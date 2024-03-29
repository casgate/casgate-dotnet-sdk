using System.Text.Json.Serialization;

namespace Casdoor.Client;

public class CasdoorUserIdProvider
{
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("lastSignInTime")]
    public DateTime? LastSignInTime { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("providerDisplayName")]
    public string? ProviderDisplayName { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("usernameFromIdp")]
    public string? UsernameFromIdp { get; set; }

    [JsonPropertyName("userId")]
    public Guid? UserId { get; set; }
}
