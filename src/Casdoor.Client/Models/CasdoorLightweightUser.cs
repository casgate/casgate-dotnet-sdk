// Copyright 2023 The Casdoor Authors. All Rights Reserved.
// Copyright 2023 The Casgate Authors. All Rights Reserved.
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

public class CasdoorLightweightUser
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    [JsonPropertyName("isAdmin")]
    public bool IsAdmin { get; set; }

    [JsonPropertyName("isForbidden")]
    public bool IsForbidden { get; set; }

    [JsonPropertyName("ldap")]
    public string? Ldap { get; set; }

    [JsonPropertyName("lastSigninTime")]
    public string? LastSigninTime { get; set; }

    [JsonPropertyName("roles")]
    public IEnumerable<CasdoorRole>? Roles { get; set; }

    [JsonPropertyName("userIdProvider")]
    public CasdoorUserIdProvider? UserIdProvider { get; set; }
}
