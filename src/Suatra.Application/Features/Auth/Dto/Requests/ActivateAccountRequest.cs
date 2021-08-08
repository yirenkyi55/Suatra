namespace Suatra.Application.Features.Auth.Dto.Requests
{
    public class ActivateAccountRequest
    {
        public string Email { get; set; }

        public string Token { get; set; }
    }
}