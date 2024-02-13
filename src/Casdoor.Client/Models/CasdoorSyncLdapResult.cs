using System.Text.Json.Serialization;

namespace Casdoor.Client;

public class CasdoorSyncLdapResult
{
    [JsonPropertyName("exist")]
    public IEnumerable<CasdoorLdapUser>? Exist { get; set; }

    [JsonPropertyName("failed")]
    public IEnumerable<CasdoorLdapUser>? Failed { get; set; }
}
