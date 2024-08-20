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

using System.Net.Http.Json;

namespace Casdoor.Client;

public partial class CasdoorClient
{
    public virtual Task<CasdoorResponse?> AddLdapAsync(CasdoorLdap ldap, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(ldap.ServerName))
        {
            ldap.ServerName = CasdoorConstants.DefaultCasdoorLdapServerName;
        }

        var url = _options.GetActionUrl("add-ldap");
        return PostAsJsonAsync(url, ldap, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> DeleteLdapAsync(string owner, string id, CancellationToken cancellationToken = default)
    {
        var application = new CasdoorLdap { Owner = owner, Id = id };
        var url = _options.GetActionUrl("delete-ldap");
        return await PostAsJsonAsync(url, application, cancellationToken);
    }

    public virtual async Task<CasdoorLdap?> GetLdapAsync(string ldapId, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("ldapId", ldapId).QueryMap;
        var url = _options.GetActionUrl("get-ldap", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorLdap?>();
    }

    public virtual async Task<IEnumerable<CasdoorLdap>?> GetLdapsAsync(string owner, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("owner", owner).QueryMap;
        var url = _options.GetActionUrl("get-ldaps", queryMap);

        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<IEnumerable<CasdoorLdap>?>();
    }

    public virtual Task<CasdoorResponse?> UpdateLdapAsync(string id, CasdoorLdap ldap, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(ldap.ServerName))
        {
            ldap.ServerName = CasdoorConstants.DefaultCasdoorLdapServerName;
        }

        var queryMap = new QueryMapBuilder().Add("id", id).QueryMap;

        var url = _options.GetActionUrl("update-ldap", queryMap);
        return PostAsJsonAsync(url, ldap, cancellationToken);
    }

    public virtual async Task<CasdoorLdapUsers?> GetLdapUsersAsync(string ldapId, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("ldapId", ldapId).QueryMap;
        var url = _options.GetActionUrl("get-ldap-users", queryMap);
        var result = await _httpClient.GetFromJsonAsync<CasdoorResponse?>(url, cancellationToken: cancellationToken);
        return result.DeserializeData<CasdoorLdapUsers?>();
    }

    public virtual Task<CasdoorResponse?> SyncLdapUsersAsync(string owner, string id, IEnumerable<CasdoorLdapUser> users, CancellationToken cancellationToken = default)
    {
        var queryMap = new QueryMapBuilder().Add("id", $"{owner}/{id}").QueryMap;
        var url = _options.GetActionUrl("sync-ldap-users", queryMap);
        return PostAsJsonAsync(url, users, cancellationToken);
    }

    public virtual Task<CasdoorResponse?> SyncLdapAllUsersAsync(string ldapId, CancellationToken cancellationToken = default)
    {
        var url = _options.GetActionUrl("v2/sync-ldap-users");
        return PostAsJsonAsync(url, new { Id = ldapId }, cancellationToken);
    }

    public virtual async Task<CasdoorResponse?> TestLdapConnectionAsync(CasdoorLdap ldap, CancellationToken cancellationToken = default)
    {
        var url = _options.GetActionUrl("test-ldap");
        return await PostAsJsonAsync(url, ldap, cancellationToken);
    }
}
