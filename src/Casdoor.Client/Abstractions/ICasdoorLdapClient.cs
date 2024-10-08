// Copyright 2024 The Casdoor Authors. All Rights Reserved.
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

public interface ICasdoorLdapClient
{
    public Task<CasdoorResponse?> AddLdapAsync(CasdoorLdap ldap, CancellationToken cancellationToken = default);

    public Task<CasdoorResponse?> DeleteLdapAsync(string owner, string id, CancellationToken cancellationToken = default);

    public Task<CasdoorLdap?> GetLdapAsync(string ldapId, CancellationToken cancellationToken = default);

    public Task<IEnumerable<CasdoorLdap>?> GetLdapsAsync(string owner, CancellationToken cancellationToken = default);

    public Task<CasdoorResponse?> SyncLdapUsersAsync(string owner, string id, IEnumerable<CasdoorLdapUser> users, CancellationToken cancellationToken = default);

    public Task<CasdoorResponse?> SyncLdapAllUsersAsync(string ldapId, CancellationToken cancellationToken = default);

    public Task<CasdoorLdapUsers?> GetLdapUsersAsync(string ldapId, CancellationToken cancellationToken = default);

    public Task<CasdoorResponse?> UpdateLdapAsync(string id, CasdoorLdap ldap, CancellationToken cancellationToken = default);

    public Task<CasdoorResponse?> TestLdapConnectionAsync(CasdoorLdap ldap, CancellationToken cancellationToken = default);
}
