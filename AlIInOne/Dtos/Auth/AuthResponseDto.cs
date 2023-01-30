namespace AlIInOne.Dtos.Auth
{
    public class AuthResponseDto
    {
        public string FullName { get; set; }
        public string Identity { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
