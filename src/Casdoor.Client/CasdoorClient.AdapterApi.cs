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

using System.Net.Http.Json;

namespace Casdoor.Client;

public partial class CasdoorClient
{
    public virtual Task<CasdoorResponse?> AddAdapterAsync(CasdoorAdapter adapter, CancellationToken cancellationToken = default) =>
        PostAsJsonAsync(_options.GetActionUrl("add-adapter"), adapter, cancellationToken);

    public virtual Task<CasdoorResponse?> UpdateAdapterAsync(CasdoorAdapter adapter, string adapterId, CancellationToken cancellationToken = default)
    {
        var url = _options.GetActionUrl("update-adapter", new QueryMapBuilder().Add("id", adapterId).QueryMap);
        return PostAsJsonAsync(url, adapter, cancellationToken);
    }

    public virtual Task<CasdoorResponse?> DeleteAdapterAsync(CasdoorAdapter adapter, CancellationToken cancellationToken = default) =>
        PostAsJsonAsync(_options.GetActionUrl("delete-adapter"), adapter, cancellationToken);

    public virtual async Task<CasdoorAdapter?> GetAdapterAsync(string name, string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("id", $"{owner ?? _options.OrganizationName}/{name}").QueryMap;
        var url = _options.GetActionUrl("get-adapter", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorAdapter?>();
    }

    public virtual async Task<IEnumerable<CasdoorAdapter>?> GetAdaptersAsync(string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("owner", owner ?? _options.OrganizationName).QueryMap;
        var url = _options.GetActionUrl("get-adapters", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<IEnumerable<CasdoorAdapter>?>();
    }
}
