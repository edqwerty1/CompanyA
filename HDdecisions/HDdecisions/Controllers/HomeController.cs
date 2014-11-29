using AutoMapper;
using AutoMapper.QueryableExtensions;
using HDdecisions.Domain.Entities;
using HDdecisions.Models;
using HDdecisions.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HDdecisions.Controllers
{
    /// <summary>
    /// Main controller, Manages applications and their suggested cards
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IApplicationService applicationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationService">Application service</param>
        public HomeController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        // Home/Index       
        /// <summary>
        /// default route, returns applicant form
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        // Home/GetApplicant       
        /// <summary>
        /// Attempts to find an applicant and populate the applicant form
        /// </summary>
        /// <param name="applicantName">Name of applicant</param>
        /// <returns>ApplicationForm view</returns>
        [HttpPost]
        public PartialViewResult GetApplicant(string applicantName)
        {
            var response = applicationService.FindApplicant(applicantName);
            ApplicationViewModel viewModel =  new ApplicationViewModel 
            { 
                FirstName = applicantName, 
                AnnualIncome = response == null ? 0 : response.AnnualIncome, 
                DateOfBirth  = response == null ? DateTime.Today : response.DateOfBirth.Date
            };
            return PartialView("ApplicationForm", viewModel);
        }
        // Home/FindCreditCards
        /// <summary>
        /// On Applicant form submit, attempts to match data against a credit card
        /// </summary>
        /// <param name="viewModel">submitted form data</param>
        /// <returns>CreditCardResult partial view, or form again if errors found</returns>
        [HttpPost]
        public PartialViewResult FindCreditCards(ApplicationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                return PartialView("ApplicationForm", viewModel);
            }

            var applicant = applicationService.FindApplicant(viewModel.FirstName);

            if (applicant == null)
            {
                applicant = applicationService.CreateApplicant(viewModel.FirstName, viewModel.DateOfBirth, viewModel.AnnualIncome);
            }
            else
            {
                applicationService.UpdateApplicant(applicant, viewModel.DateOfBirth, viewModel.AnnualIncome);

            }

            var response = applicationService.GetCreditCard(applicant);

            return PartialView("CreditCardResult", response);
        }

        // Home/Applicants
        /// <summary>
        /// Lists all previous applicants
        /// </summary>
        /// <returns>Applicants view</returns>
        public ViewResult Applicants()
        {
            Mapper.CreateMap<Applicant, ApplicantsViewModel>();

            IQueryable<ApplicantsViewModel> applicants = applicationService.GetApplicants().Project().To<ApplicantsViewModel>();
                
               
            return View(applicants);
        }

    }
}