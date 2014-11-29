using System;

namespace HDdecisions.Domain.Entities
{
    /// <summary>
    /// Stores information on previous applicants 
    /// </summary>
    public class Applicant : BaseEntity
    {
        /// <summary>
        /// Constructor, needed by EF, Do not use otherwise
        /// </summary>
        protected Applicant()
        {

        }

        /// <summary>
        /// Main constructor, takes all parameters necessary to create a valid applicant
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="dateOfBirth">Date of Birth</param>
        /// <param name="annualIncome">Annual Income (£? TODO decide)</param>
        public Applicant(string firstName, DateTime dateOfBirth, decimal annualIncome)
        {
            this.FirstName = firstName;
            this.DateOfBirth = dateOfBirth;
            this.AnnualIncome = annualIncome;
            this.LastUsed = DateTime.Now;
            this.Response = Response.None;
        }

        /// <summary>
        /// Applicants first name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Applicants Date of Birth
        /// </summary>
        public DateTime DateOfBirth { get; private set; }

        public decimal AnnualIncome { get; private set; }

        public DateTime LastUsed { get; private set; }

        public Response Response { get; private set; }


        public void UpdateApplicant(DateTime dateOfBirth, decimal annualIncome)
        {
            this.AnnualIncome = annualIncome;
            this.DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Update this applicants suggested credit card
        /// </summary>
        /// <param name="response"></param>
        public void UpdateResponse(Response response)
        {
            this.Response = response;
            this.LastUsed = DateTime.Now;
        }

        /// <summary>
        /// Calculates applicants age from his date of birth
        /// #TODO decide how dates are stored
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }

        }

    }
}
