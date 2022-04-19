namespace VanDsi.Core.DTOs
{
    public class UserDto : BaseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NameLastName { get; set; }
        public DateTime? RefreshTokenAndDate { get; set; }
    }
}