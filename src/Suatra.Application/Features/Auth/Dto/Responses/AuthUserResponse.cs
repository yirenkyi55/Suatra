namespace Suatra.Application.Features.Auth.Dto.Responses
{
    public class AuthUserResponse
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string OtherName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public string PhotoUri { get; set; }

        public string AccessToken { get; set; }
    }
}