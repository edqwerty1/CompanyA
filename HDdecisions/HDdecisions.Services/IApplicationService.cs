using HDdecisions.Domain.Entities;
using System;
using System.Linq;

namespace HDdecisions.Services
{
    /// <summary>
    /// Application Service
    /// Provides CRUD and extra functionality for applicants
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Find applicant by first name
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <returns>applicant if found else null</returns>
        Applicant FindApplicant(string firstName);


        /// <summary>
        /// Create a new applicant, persists it
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="dateOfBirth">Date of Birth</param>
        /// <param name="annualIncome">Annual income</param>
        /// <returns></returns>
        Applicant CreateApplicant(string firstName, DateTime dateOfBirth, decimal annualIncome);

        void UpdateApplicant(Applicant applicant, DateTime dateOfBirth, decimal annualIncome);

        /// <summary>
        /// Calculates which credit card is best for the applicant
        /// </summary>
        /// <param name="applicant">applicant to check</param>
        /// <returns>Suggested Credit card</returns>
        Response GetCreditCard(Applicant applicant);

        /// <summary>
        /// Gets all previous applicants from persistence
        /// </summary>
        /// <returns>list of applicants</returns>
        IQueryable<Applicant> GetApplicants();
    }
}
