using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlateApp.Model;

namespace GreenSlateApp.DataLayer
{
    public class CreateProjectItemConfiguration : EntityTypeConfiguration<CreateProjectItem>
    {

        public CreateProjectItemConfiguration()
        {
            Property(soi => soi.StartDate).HasMaxLength(30).IsRequired();
            Property(soi => soi.EndDate).HasMaxLength(30).IsRequired();
            Property(soi => soi.Credits).IsRequired();
            Ignore(soi => soi.ObjectState);

        }
    }
}




