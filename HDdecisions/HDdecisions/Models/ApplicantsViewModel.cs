using HDdecisions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HDdecisions.Models
{
    /// <summary>
    /// Applicants view model
    /// Used to display details on previous applicants
    /// </summary>
    public class ApplicantsViewModel
    {

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [DisplayName("Annual Income")]
        public decimal AnnualIncome { get; set; }

        [DisplayName("Last Visited")]
        public DateTime LastUsed { get; set; }

        [DisplayName("Response Given")]
        public Response Response { get; set; }

    }
}