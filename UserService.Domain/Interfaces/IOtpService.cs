namespace UserService.Domain.Interfaces
{
    public interface IOtpService
    {
        Task GenerateAndSendOtpAsync(string phoneNumber, CancellationToken ct = default);
        Task<bool> ValidateOtpAsync(string phoneNumber, string otp, CancellationToken ct = default);
    }
}
