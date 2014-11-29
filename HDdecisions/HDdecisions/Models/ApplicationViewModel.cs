using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HDdecisions.Models
{
    /// <summary>
    /// Application View Model
    /// Used by applicant form
    /// </summary>
    public class ApplicationViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Annual Income")]
        public decimal AnnualIncome { get; set; }
    }
}