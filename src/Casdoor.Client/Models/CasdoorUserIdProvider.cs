// Copyright 2022 The Casdoor Authors. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
