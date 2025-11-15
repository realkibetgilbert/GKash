namespace UserService.Application.Dtos.Auth
{
    public class LoginResultDto
    {
        public long UserId { get; set; }
        public bool IsProfileComplete { get; set; }
        public string? Message { get; set; }
    }
}
