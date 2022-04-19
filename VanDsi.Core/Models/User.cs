namespace VanDsi.Core.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NameLastName { get; set; }
        public bool IsDelete { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenAndDate { get; set; }
    }
}
