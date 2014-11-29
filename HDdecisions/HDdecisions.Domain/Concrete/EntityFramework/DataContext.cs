using HDdecisions.Domain.Concrete.EntityFramework.Mapping;
using HDdecisions.Domain.Entities;
using System.Configuration;
using System.Data.Entity;

namespace HDdecisions.Domain.Concrete.EntityFramework
{
    /// <summary>
    /// Applications DbContext
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Set of applicants
        /// Used to persist previous requests
        /// </summary>
        public DbSet<Applicant> Applicants { get; set; }

        /// <summary>
        /// Constructor
        /// Uses DefaultConnection from web.config to build local DB
        /// </summary>
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        /// <summary>
        /// Add mapping files to EF model
        /// </summary>
        /// <param name="modelBuilder">EF model builder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicantMap());
        }
    }
}
