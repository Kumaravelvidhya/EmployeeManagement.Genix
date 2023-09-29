using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5),MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(DateTime), "1970 - 01 - 01", "2004 - 01-01")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public decimal Experience { get; set; }
        [Required]

        [RegularExpression(@"^[0-9]{10}$")]

        public long Phonenumber { get; set; }
        [MinLength(5), MaxLength(50)]
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

    }
}
