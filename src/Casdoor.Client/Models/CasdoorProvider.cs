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

public class CasdoorProvider
{
    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("createdTime")]
    public string? CreatedTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("subType")]
    public string? SubType { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("clientId2")]
    public string? ClientId2 { get; set; }

    [JsonPropertyName("clientSecret2")]
    public string? ClientSecret2 { get; set; }

    [JsonPropertyName("nameIdFormat")]
    public string? NameIdFormat { get; set; }

    [JsonPropertyName("signatureAlgorithm")]
    public string? SignatureAlgorithm { get; set; }

    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    [JsonPropertyName("customAuthUrl")]
    public string? CustomAuthUrl { get; set; }

    [JsonPropertyName("customScope")]
    public string? CustomScope { get; set; }

    [JsonPropertyName("customTokenUrl")]
    public string? CustomTokenUrl { get; set; }

    [JsonPropertyName("customUserInfoUrl")]
    public string? CustomUserInfoUrl { get; set; }

    [JsonPropertyName("customLogo")]
    public string? CustomLogo { get; set; }

    [JsonPropertyName("scopes")]
    public string? Scopes { get; set; }

    [JsonPropertyName("userMapping")]
    public ProviderUserMapping? UserMapping { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("disableSsl")]
    public bool? DisableSsl { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("receiver")]
    public string? Receiver { get; set; }

    [JsonPropertyName("regionId")]
    public string? RegionId { get; set; }

    [JsonPropertyName("roleMappingItems")]
    public ProviderRoleMappingItem[]? RoleMappingItems { get; set; }

    [JsonPropertyName("signName")]
    public string? SignName { get; set; }

    [JsonPropertyName("templateCode")]
    public string? TemplateCode { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("intranetEndpoint")]
    public string? IntranetEndpoint { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("enableRoleMapping")]
    public bool? EnableRoleMapping { get; set; }

    [JsonPropertyName("bucket")]
    public string? Bucket { get; set; }

    [JsonPropertyName("pathPrefix")]
    public string? PathPrefix { get; set; }

    [JsonPropertyName("metadata")]
    public string? Metadata { get; set; }

    [JsonPropertyName("idP")]
    public string? IdP { get; set; }

    [JsonPropertyName("issuerUrl")]
    public string? IssuerUrl { get; set; }

    [JsonPropertyName("requestSignature")]
    public string? RequestSignature { get; set; }

    [JsonPropertyName("validateIdpSignature")]
    public string? ValidateIdpSignature { get; set; }

    [JsonPropertyName("providerUrl")]
    public string? ProviderUrl { get; set; }
}

public class ProviderUserMapping
{
    [JsonPropertyName("id")]
    public string[] Id { get; set; }

    [JsonPropertyName("username")]
    public string[] Username { get; set; }

    [JsonPropertyName("email")]
    public string[] Email { get; set; }

    [JsonPropertyName("displayName")]
    public string[] DisplayName { get; set; }

    [JsonPropertyName("avatarUrl")]
    public string[] AvatarUrl { get; set; }
}

public class ProviderRoleMappingItem
{
    [JsonPropertyName("attribute")]
    public string? Attribute { get; set; }

    [JsonPropertyName("values")]
    public string[]? Values { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }
}

