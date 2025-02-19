namespace Domain.DTOs.Users
{
    public class UserLoginReturnDTO
    {
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
        public int Expired_Time { get; set; }
    }
}
