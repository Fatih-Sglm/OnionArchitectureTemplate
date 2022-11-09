namespace Application.Features.Auth.Dtos
{
    public class RegisterAppUserDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
