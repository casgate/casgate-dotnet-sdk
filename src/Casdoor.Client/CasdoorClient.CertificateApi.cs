﻿// Copyright 2022 The Casdoor Authors. All Rights Reserved.
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

using System.Net.Http.Json;

namespace Casdoor.Client;

public partial class CasdoorClient
{
    public virtual async Task<IEnumerable<CasdoorCertificate>?> GetCertificatesAsync(string? owner = null,  string? filterFieldName = null, string? filterFieldValue = null, CancellationToken cancellationToken = default)
    {
        var builder = new QueryMapBuilder().Add("owner", owner ?? _options.OrganizationName);

        if (!string.IsNullOrEmpty(filterFieldName))
        {
            builder.Add("field", filterFieldName);
            builder.Add("value", filterFieldValue);
        }

        var queryMap = builder.QueryMap;

        string url = _options.GetActionUrl("get-certs", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<IEnumerable<CasdoorCertificate>?>();
    }

    public virtual async Task<CasdoorCertificate?> GetCertificateAsync(string name, string? owner = null,
        CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("id", $"{owner ?? _options.OrganizationName}/{name}").QueryMap;
        string url = _options.GetActionUrl("get-cert", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorCertificate?>();
    }

    public virtual async Task<CasdoorResponse?> AddCertificateAsync(CasdoorCertificate certificate, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(certificate.Owner))
        {
            certificate.Owner = CasdoorConstants.DefaultCasdoorOwner;
        }

        string url = _options.GetActionUrl("add-cert");
        return await PostAsJsonAsync(url, certificate, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> UpdateCertificateAsync(CasdoorCertificate certificate, string name, string? owner = null,
        CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("id", $"{owner ?? _options.OrganizationName}/{name}").QueryMap;
        string url = _options.GetActionUrl("update-cert", queryMap);
        return await PostAsJsonAsync(url, certificate, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> DeleteCertificateAsync(CasdoorCertificate certificate, CancellationToken cancellationToken = default) =>
        await PostAsJsonAsync(_options.GetActionUrl("delete-cert"), certificate, cancellationToken);
}
