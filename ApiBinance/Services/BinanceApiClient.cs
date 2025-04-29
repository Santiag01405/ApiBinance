using Microsoft.Extensions.Options;
using ApiBinance.Models;
using ApiBinance.Configurations;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ApiBinance.Services
{
    public class BinanceApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly BinanceSettings _settings;

        public BinanceApiClient(HttpClient httpClient, IOptions<BinanceSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }

        private string Sign(string payload)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        public async Task<string> PostAdAsync(AdPublishRequest adPayload)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var fullUrl = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/post?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(adPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, fullUrl);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {responseBody}");

            return responseBody;
        }

        public async Task<string> GetAdDetailAsync(string adsNo)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"adsNo={adsNo}&timestamp={timestamp}";
            var signature = Sign(queryString);
            var fullUrl = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/getDetailByNo?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateAdAsync(AdUpdateRequest update)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/update?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(update);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> UpdateAdStatusAsync(AdUpdateStatusRequest requestPayload)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/updateStatus?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> ReleaseCoinAsync(ReleaseCoinRequest requestPayload)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/orderMatch/releaseCoin?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> GetChatImageUploadUrlAsync(ChatImageUrlRequest requestPayload)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/chat/image/pre-signed-url?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> MarkMessagesAsReadAsync(MarkMessagesReadRequest requestPayload)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/chat/markOrderMessagesAsRead?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> GetChatCredentialsAsync()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/chat/retrieveChatCredential?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> GetChatMessagesPaginatedAsync(ChatMessagesQueryParams query)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            var queryParams = new Dictionary<string, string?>
            {
                ["timestamp"] = timestamp.ToString(),
                ["chatMessageType"] = query.ChatMessageType,
                ["id"] = query.Id?.ToString(),
                ["order"] = query.Order,
                ["orderNo"] = query.OrderNo,
                ["page"] = query.Page.ToString(),
                ["rows"] = query.Rows.ToString(),
                ["sort"] = query.Sort
            };

            var filteredParams = queryParams
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                .Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value!)}");

            var queryString = string.Join("&", filteredParams);
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/chat/retrieveChatMessagesWithPagination?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }
    }
}
