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
using System.Text.Json;

namespace Casdoor.Client;

public partial class CasdoorClient
{
    internal async Task<TValue?> GetFromJsonAsync<TValue>(string? requestUri, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        using var stream = await response.Content.ReadAsStreamAsync();
        TValue? successResult;
        try
        {
            successResult = await JsonSerializer.DeserializeAsync<TValue>(stream, cancellationToken: cancellationToken);
        }
        catch (JsonException e)
        {
            throw new CasdoorApiException($"Server response cannot be deserialized as type {typeof(TValue).FullName}. Server API and SDK implementation are inconsistent.", e);
        }
        return successResult;
    }

    internal async Task<CasdoorResponse?> PostAsJsonAsync<TValue>(string? requestUri, TValue value, CancellationToken cancellationToken = default)
    {
        _httpClient.SetCasdoorAuthentication(_options);
        HttpResponseMessage resp = await _httpClient.PostAsJsonAsync(requestUri, value, cancellationToken);
        return await resp.ToCasdoorResponse(cancellationToken);
    }

    internal async Task<CasdoorResponse?> PostAsMultipartAsync(string? requestUri, Dictionary<string, string> param, CancellationToken cancellationToken = default)
    {
        var multiPartContent = new MultipartFormDataContent();

        foreach (var pair in param)
        {
            var stringContent = new StringContent(pair.Value);
            multiPartContent.Add(stringContent, pair.Key);
        }
        _httpClient.SetCasdoorAuthentication(_options);
        HttpResponseMessage resp = await _httpClient.PostAsync(requestUri, multiPartContent, cancellationToken);
        return await resp.ToCasdoorResponse(cancellationToken);
    }
}
