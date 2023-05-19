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

namespace Casdoor.Client;

public interface ICasdoorApplicationClient
{
    public Task<CasdoorResponse?> AddApplicationAsync(CasdoorApplication application);
    public Task<CasdoorResponse?> DeleteApplicationAsync(string name);
    public Task<CasdoorResponse?> UpdateApplicationAsync(string id, CasdoorApplication newApplication);
    public Task<CasdoorApplication?> GetApplicationAsync(string id);
    
    public Task<IEnumerable<CasdoorApplication>?> GetApplicationsAsync(string owner);
    public Task<IEnumerable<CasdoorApplication>?> GetOrganizationApplicationsAsync(string organization);
    public Task<CasdoorApplication?> GetUserApplicationAsync(string id);
}