using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlateApp.Model;

namespace GreenSlateApp.DataLayer
{
    public class ProjectContext :DbContext
    {

        public ProjectContext() : base("MyDB")
        {

        }


        public DbSet<CreateProject> CreateProjects { get; set; }
        public DbSet<CreateProjectItem> CreateProjectItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CreateProjectConfiguration());
            modelBuilder.Configurations.Add(new CreateProjectItemConfiguration());
        }
    }
}
