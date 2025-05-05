using Microsoft.Extensions.Options;
using ApiBinance.Models;
using ApiBinance.Configurations;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.IO.Compression;
using System.Net.Http.Headers;


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


        public async Task<BinanceUserOrderListResponse> GetUserOrdersAuthenticatedAsync()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/orderMatch/listUserOrderHistory?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");
            request.Content = new StringContent("{}", Encoding.UTF8, "application/json"); // obligatorio aunque vacío

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return JsonSerializer.Deserialize<BinanceUserOrderListResponse>(body, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
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
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);
            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/getDetailByNo?{queryString}&signature={signature}";

            var json = JsonSerializer.Serialize(new { adsNo });
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


        /* public async Task<string> GetAdDetailAsync(string adsNo)
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
         }*/


           /* var queryString = $"adsNo={adsNo}&timestamp={timestamp}";
            var signature = Sign(queryString);
            var fullUrl = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/getDetailByNo?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }*/

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

        public async Task<string> GetAvailableAdsCategoriesAsync()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var queryString = $"timestamp={timestamp}";
            var signature = Sign(queryString);

            var url = $"{_settings.BaseUrl}/sapi/v1/c2c/ads/getAvailableAdsCategory?{queryString}&signature={signature}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-MBX-APIKEY", _settings.ApiKey);
            request.Headers.Add("clientType", "web");

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body;
        }

        public async Task<string> GetUserOrdersAsync()
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://p2p.binance.com/bapi/c2c/v2/friendly/c2c/order/list");

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.UserAgent.ParseAdd("Mozilla/5.0"); // Necesario para Binance

                var response = await _httpClient.SendAsync(request);

                string body;

                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                {
                    using var stream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress);
                    using var reader = new StreamReader(stream);
                    body = await reader.ReadToEndAsync();
                }
                else
                {
                    body = await response.Content.ReadAsStringAsync();
                }

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Binance API Error: {(int)response.StatusCode} - {body}");
                }

                return body;
            }




    /* public async Task<string> GetUserOrdersAsync(UserOrderListRequest payload)
     {
         var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
         var queryString = $"timestamp={timestamp}";
         var signature = Sign(queryString);
         var url = $"{_settings.BaseUrl}/sapi/v1/c2c/orderMatch/userOrderList?{queryString}&signature={signature}";

         var json = JsonSerializer.Serialize(payload);
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
     }*/

    public async Task<string> GetPublicAdsAsync(PublicAdvSearchRequest request)
        {
            var url = "https://p2p.binance.com/bapi/c2c/v2/friendly/c2c/adv/search";
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            httpRequest.Headers.Remove("Accept-Encoding");
            httpRequest.Headers.Add("Accept-Encoding", "identity"); // desactiva gzip

            var response = await _httpClient.SendAsync(httpRequest);
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException($"Binance API Error: {(int)response.StatusCode} - {body}");

            return body; // <-- crudo, JSON puro, igual que Postman
        }
    }
}
