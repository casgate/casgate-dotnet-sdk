using System.Text.Json.Serialization;

namespace Casdoor.Client;

public class CasdoorCertificate
{
    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("cryptoAlgorithm")]
    public string? CryptoAlgorithm { get; set; }

    [JsonPropertyName("bitSize")]
    public int? BitSize { get; set; }

    [JsonPropertyName("expireInYears")]
    public int? ExpireInYears { get; set; }

    [JsonPropertyName("certificate")]
    public string? Certificate { get; set; }

    [JsonPropertyName("privateKey")]
    public string? PrivateKey { get; set; }
}
