using HDdecisions.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HDdecisions.Domain.Concrete.EntityFramework.Mapping
{
    class ApplicantMap : EntityTypeConfiguration<Applicant>
    {
        public ApplicantMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }
}
