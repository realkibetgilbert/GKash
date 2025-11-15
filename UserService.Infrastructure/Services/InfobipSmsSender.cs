using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using UserService.Domain.Interfaces;

namespace UserService.Infrastructure.Services
{
    public class InfobipSmsSender : ISmsSender
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public InfobipSmsSender(IHttpClientFactory httpFactory, IConfiguration config)
        {
            _httpFactory = httpFactory;
            _apiKey = config["Infobip:ApiKey"] ?? throw new ArgumentNullException("Infobip:ApiKey");
            _baseUrl = config["Infobip:BaseUrl"]?.TrimEnd('/') ?? throw new ArgumentNullException("Infobip:BaseUrl");
        }

        public async Task SendAsync(string phoneNumber, string message)
        {
            var client = _httpFactory.CreateClient("infobip");
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Add("Authorization", $"App {_apiKey}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var payload = new
            {
                messages = new[]
                {
                    new {
                        destinations = new[] { new { to = phoneNumber } },
                        from = "ServiceSMS",
                        text = message
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var resp = await client.PostAsync("/sms/2/text/advanced", content);
            resp.EnsureSuccessStatusCode();
        }
    }
}
