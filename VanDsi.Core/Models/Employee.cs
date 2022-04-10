namespace VanDsi.Core.Models
{
    public class Employee : BaseEntity
    {
        public string TcNo { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string DateOfEmployment { get; set; }
        public string NameLastName { get; set; }
        public string FirstLastName { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public ICollection<Labor> Labors { get; set; }
        public User User { get; set; }
    }
}
