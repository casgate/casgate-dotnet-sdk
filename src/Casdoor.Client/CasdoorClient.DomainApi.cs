// Copyright 2023 The Casdoor Authors. All Rights Reserved.
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
    public virtual async Task<CasdoorResponse?> AddDomainAsync(CasdoorDomain domain, CancellationToken cancellationToken = default) =>
        await PostAsJsonAsync(_options.GetActionUrl("add-domain"), domain, cancellationToken);

    public virtual async Task<CasdoorResponse?> UpdateDomainAsync(CasdoorDomain domain, string domainId,
        CancellationToken cancellationToken = default)
    {
        string url = _options.GetActionUrl("update-domain", new QueryMapBuilder().Add("id", domainId).QueryMap);
        return await PostAsJsonAsync(url, domain, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> DeleteDomainAsync(CasdoorDomain domain, CancellationToken cancellationToken = default)
    {
        string url = _options.GetActionUrl("delete-domain");
        return await PostAsJsonAsync(url, domain, cancellationToken);
    }

    public virtual async Task<CasdoorDomain?> GetDomainAsync(string name, string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("id", $"{owner ?? _options.OrganizationName}/{name}").QueryMap;
        string url = _options.GetActionUrl("get-domain", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorDomain?>();
    }

    public virtual async Task<IEnumerable<CasdoorDomain>?> GetDomainsAsync(string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("owner", owner ?? _options.OrganizationName).QueryMap;
        string url = _options.GetActionUrl("get-domains", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<IEnumerable<CasdoorDomain>?>();
    }
}