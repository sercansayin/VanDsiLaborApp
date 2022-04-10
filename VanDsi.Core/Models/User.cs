namespace VanDsi.Core.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NameLastName { get; set; }
        public bool IsDelete { get; set; }
        public string RefleshToken { get; set; }
        public DateTime? RefleshTokenAndDate { get; set; }
    }
}
