using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Interfaces;

namespace UserService.Infrastructure.Services
{
    public class OtpService : IOtpService
    {
        private readonly IDistributedCache _cache;
        private readonly ISmsSender _sms; // Your Infobip sender

        public OtpService(IDistributedCache cache, ISmsSender sms)
        {
            _cache = cache;
            _sms = sms;
        }

        public async Task GenerateAndSendOtpAsync(string phoneNumber, CancellationToken ct = default)
        {
            // 1. Generate 6-digit OTP
            var otp = new Random().Next(100000, 999999).ToString();

            // 2. Store in Redis
            await _cache.SetStringAsync(
                $"otp:{phoneNumber}",
                otp,
                new DistributedCacheEntryOptions(),
                ct
            );

            // 3. Send SMS via Infobip
            await _sms.SendAsync(phoneNumber, $"Your GKash OTP is {otp}");
        }

        public async Task<bool> ValidateOtpAsync(string phoneNumber, string otp, CancellationToken ct = default)
        {
            var stored = await _cache.GetStringAsync($"otp:{phoneNumber}", ct);

            if (stored == null || stored != otp)
                return false;

            return true;
        }
    }
}