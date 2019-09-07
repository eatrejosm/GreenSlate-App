using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlateApp.Model;

namespace GreenSlateApp.DataLayer
{
    public class CreateProjectConfiguration : EntityTypeConfiguration<CreateProject>
    {

        public CreateProjectConfiguration()
        {
            Property(so => so.FirstName).HasMaxLength(30).IsRequired();
            Property(so => so.LastName).HasMaxLength(30).IsRequired();
            Ignore(so => so.ObjectState);
        }
    }
}
