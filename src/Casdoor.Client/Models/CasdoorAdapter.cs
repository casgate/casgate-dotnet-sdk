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

public sealed class CasdoorAdapter
{
    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("table")]
    public string? Table { get; set; }

    [JsonPropertyName("createdTime")]
    public string? CreatedTime { get; set; }

    [JsonPropertyName("useSameDb")]
    public bool UseSameDb { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("databaseType")]
    public string? DatabaseType { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("database")]
    public string? Database { get; set; }
}
