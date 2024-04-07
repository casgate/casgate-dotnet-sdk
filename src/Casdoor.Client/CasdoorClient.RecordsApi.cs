// Copyright 2024 The Casgate Authors. All Rights Reserved.
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

namespace Casdoor.Client;

public partial class CasdoorClient
{
    public virtual async Task<IEnumerable<CasgateRecord>?> GetRecordsAsync(
        int pageSize = default,
        int p = default,
        string? field = default,
        string? value = default,
        string? sortField = default,
        string? sortOrder = default,
        string? fromDate = default,
        string? endDate = default,
        string? organizationName = default,
        CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder()
            .Add(nameof(pageSize), pageSize != default ? pageSize.ToString() : null)
            .Add(nameof(p), p != default ? p.ToString() : null)
            .Add(nameof(field), field)
            .Add(nameof(value), value)
            .Add(nameof(sortField), sortField)
            .Add(nameof(sortOrder), sortOrder)
            .Add(nameof(fromDate), fromDate)
            .Add(nameof(endDate), endDate)
            .Add(nameof(organizationName), organizationName)
            .QueryMap;
        var url = _options.GetActionUrl("get-records", queryMap);
        var response = await GetFromJsonAsync<CasdoorResponse>(url, cancellationToken: cancellationToken);
        return response.DeserializeData<IEnumerable<CasgateRecord>>();
    }
}
