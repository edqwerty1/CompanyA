using System;
using System.Linq;
using System.Data.Entity;
using HDdecisions.Domain.Entities;

namespace HDdecisions.Services.Implementation
{
    /// <summary>
    /// Concrete implementation of IApplicationService
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        private readonly DbContext context;
        private readonly DbSet<Applicant> applicants;

        /// <summary>
        /// Constructor,
        /// </summary>
        /// <param name="context">apps persistance context</param>
        public ApplicationService(DbContext context)
        {
            this.context = context;
            this.applicants = context.Set<Applicant>();
        }


        public Applicant FindApplicant(string firstName)
        {
            var applicant = applicants.FirstOrDefault(t => t.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase));
            return applicant;
        }

        public Applicant CreateApplicant(string firstName, DateTime dateOfBirth, decimal annualIncome)
        {
            var applicant = new Applicant(firstName, dateOfBirth, annualIncome);
            applicants.Add(applicant);
            context.SaveChanges();

            return applicant;
        }

        public void UpdateApplicant(Applicant applicant, DateTime dateOfBirth, decimal annualIncome)
        {
            applicant.UpdateApplicant(dateOfBirth, annualIncome);

            context.SaveChanges();
        }



        public Response GetCreditCard(Applicant applicant)
        {
            Response response;

            if (applicant == null)
            {
                throw new ArgumentNullException("applicant", "Applicant must be provided");
            }

            if (applicant.Age < 18)
            {
                response = Response.NoCardsAvailable;
            }
            else
            {
                if (applicant.AnnualIncome > 30000)
                {
                    response = Response.Barclaycard;
                }
                else
                {
                    response = Response.Vanquis;
                }
            }          

            applicant.UpdateResponse(response);
            context.SaveChanges();

            return response;

        }

        public IQueryable<Applicant> GetApplicants()
        {
            return applicants;
        }
    }
}
