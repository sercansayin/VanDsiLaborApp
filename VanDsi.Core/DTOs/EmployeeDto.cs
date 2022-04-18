using VanDsi.Core.Models;

namespace VanDsi.Core.DTOs
{
    public class EmployeeDto : BaseDto
    {
        public string TcNo { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string DateOfEmployment { get; set; }
        public string NameLastName { get; set; }
        public string FirstLastName { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public ICollection<LaborDto> Labors { get; set; }
    }
}
