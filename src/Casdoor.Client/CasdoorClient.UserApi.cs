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
    public virtual async Task<IEnumerable<CasdoorUser>?> GetUsersAsync(string? owner = null, string? filterFieldName = null, string? filterFieldValue = null,
        bool fillUserIdProvider = false,
        CancellationToken cancellationToken = default)
    {
        var builder = new QueryMapBuilder()
            .Add("owner", owner ?? _options.OrganizationName)
            .Add("fillUserIdProvider", fillUserIdProvider.ToString().ToLower());

        if (!string.IsNullOrEmpty(filterFieldName) && !string.IsNullOrEmpty(filterFieldValue))
        {
            builder.Add("field", filterFieldName);
            builder.Add("value", filterFieldValue);
        }

        var queryMap = builder.QueryMap;
        string url = _options.GetActionUrl("get-users", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<IEnumerable<CasdoorUser>?>();
    }

    public virtual async Task<(IEnumerable<CasdoorLightweightUser>?, int)> GetLightweightUsersAsync(string? owner = null, int page = 1, int pageSize = 500, string? filterFieldName = null, string? filterFieldValue = null, bool fillUserIdProvider = false, CancellationToken cancellationToken = default)
    {
        var builder = new QueryMapBuilder()
            .Add("owner", owner ?? _options.OrganizationName)
            .Add("fillUserIdProvider", fillUserIdProvider.ToString().ToLower())
            .Add("p", page.ToString())
            .Add("pageSize", pageSize.ToString())
            .Add("sortField", "name")
            .Add("sortOrder", "ascend");

        if (!string.IsNullOrEmpty(filterFieldName) && !string.IsNullOrEmpty(filterFieldValue))
        {
            builder.Add("field", filterFieldName);
            builder.Add("value", filterFieldValue);
        }

        var queryMap = builder.QueryMap;
        string url = _options.GetActionUrl("get-users", queryMap);
        try
        {
            var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
            int.TryParse(result?.Data2?.ToString(), out var usersCount);
            return (result.DeserializeData<IEnumerable<CasdoorLightweightUser>?>(), usersCount);
        }
        catch
        {
            return ([], 0);
        }
    }

    public virtual async Task<IEnumerable<CasdoorUser>?> GetSortedUsersAsync(string sorter, int limit, string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder()
            .Add("owner", owner ?? _options.OrganizationName)
            .Add("sorter", sorter)
            .Add("limit", limit.ToString())
            .QueryMap;
        string url = _options.GetActionUrl("get-sorted-users", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<IEnumerable<CasdoorUser>?>();
    }

    public virtual async Task<CasdoorLightweightUser?> GetLightweightUserAsync(string name, string? owner = null, bool fillUserIdProvider = false, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder()
            .Add("id", $"{owner ?? _options.OrganizationName}/{name}")
            .Add("fillUserIdProvider", fillUserIdProvider ? "true" : "false")
            .QueryMap;
        string url = _options.GetActionUrl("get-user", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorLightweightUser?>();
    }

    public virtual async Task<CasdoorUser?> GetUserAsync(string name, string? owner = null, bool fillUserIdProvider = false, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder()
            .Add("id", $"{owner ?? _options.OrganizationName}/{name}")
            .Add("fillUserIdProvider", fillUserIdProvider ? "true" : "false")
            .QueryMap;
        string url = _options.GetActionUrl("get-user", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorUser?>();
    }

    public virtual async Task<CasdoorUser?> GetUserByIdAsync(string id, string? owner = null, bool fillUserIdProvider = false, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder()
            .Add("userId", id)
            .Add("owner", owner ?? _options.OrganizationName)
            .Add("fillUserIdProvider", fillUserIdProvider ? "true" : "false")
            .QueryMap;
        string url = _options.GetActionUrl("get-user", queryMap);
        var result = await GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorUser?>();
    }

    public virtual async Task<CasdoorUser?> GetUserByEmailAsync(string email, string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder()
            .Add("owner", _options.OrganizationName)
            .Add("email", email)
            .QueryMap;
        string url = _options.GetActionUrl("get-user", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorUser?>();
    }

    public virtual Task<CasdoorResponse?> AddUserAsync(CasdoorUser user, CancellationToken cancellationToken = default)
        => ModifyUserAsync("add-user", user, null, cancellationToken: cancellationToken);

    public virtual Task<CasdoorResponse?> UpdateUserAsync(CasdoorUser user,  IEnumerable<string> propertyNames, CancellationToken cancellationToken = default)
        => ModifyUserAsync("update-user", user, propertyNames, cancellationToken: cancellationToken);

    public Task<CasdoorResponse?> UpdateUserForbiddenFlagAsync(CasdoorUser user, CancellationToken cancellationToken = default)
    {
        user.IsForbidden = !user.IsForbidden;
        return UpdateUserAsync(user, new List<string> { "is_forbidden" }, cancellationToken);
    }

    public Task<CasdoorResponse?> UpdateUserDeletedFlagAsync(CasdoorUser user, CancellationToken cancellationToken = default)
    {
        user.IsDeleted = !user.IsDeleted;
        return UpdateUserAsync(user, new List<string> { "is_deleted" }, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> DeleteUserAsync(string name, string? owner,
        CancellationToken cancellationToken = default)
    {
        CasdoorUser? user = await GetUserAsync(name, owner, cancellationToken: cancellationToken);
        if (user is null)
        {
            return null;
        }
        return await ModifyUserAsync("delete-user", user, null, owner: owner, cancellationToken: cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> DeleteUserAsync(CasdoorUser user,
        CancellationToken cancellationToken = default)
    {
        return await ModifyUserAsync("delete-user", user, null, cancellationToken: cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> AddUserIdProvider(CasdoorUserIdProvider userIdProvider, CancellationToken cancellationToken = default)
    {
        var url = _options.GetActionUrl("add-user-id-provider");
        return await PostAsJsonAsync(url, userIdProvider, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> CheckUserPasswordAsync(string name, CancellationToken cancellationToken = default)
    {
        CasdoorUser? user = await GetUserAsync(name, cancellationToken: cancellationToken);
        if (user is null)
        {
            return null;
        }
        return await ModifyUserAsync("check-user-password", user, null, cancellationToken: cancellationToken);
    }

    private Task<CasdoorResponse?> ModifyUserAsync(string action, CasdoorUser user, IEnumerable<string>? columns, string? owner = null, CancellationToken cancellationToken = default)
    {
        var queryMapBuilder = new QueryMapBuilder().Add("id", $"{user.Owner}/{user.Name}");

        string columnsValue = string.Join(",", columns ?? Array.Empty<string>());

        if (!string.IsNullOrEmpty(columnsValue))
        {
            queryMapBuilder.Add("columns", columnsValue);
        }

        user.Owner = owner ?? user.Owner ?? _options.OrganizationName;
        string url = _options.GetActionUrl(action, queryMapBuilder.QueryMap);
        return PostAsJsonAsync(url, user, cancellationToken);
    }
}
