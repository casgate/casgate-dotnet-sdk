using System.Text.Json.Serialization;

namespace Casdoor.Client;

public class CasdoorUserIdProvider
{
    [JsonPropertyName("createdTime")]
    [JsonConverter(typeof(NullableDateTimeConverter))]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("lastSignInTime")]
    [JsonConverter(typeof(NullableDateTimeConverter))]
    public DateTime? LastSignInTime { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("providerDisplayName")]
    public string? ProviderDisplayName { get; set; }

    [JsonPropertyName("ldapServerName")]
    public string? LdapServerName { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("usernameFromIdp")]
    public string? UsernameFromIdp { get; set; }

    [JsonPropertyName("ldapId")]
    public string? LdapId { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
