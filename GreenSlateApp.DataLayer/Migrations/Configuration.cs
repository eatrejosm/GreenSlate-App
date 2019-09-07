namespace GreenSlateApp.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GreenSlateApp.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<GreenSlateApp.DataLayer.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GreenSlateApp.DataLayer.ProjectContext context)
        {
            context.CreateProjects.AddOrUpdate(
                    so => so.FirstName,
                    new CreateProject {
                        FirstName = "Esteban", LastName = "Trejos", CreateProjectItems=
                        {
                            new CreateProjectItem{StartDate = "9/5/2019", EndDate = "12/5/2019", Credits= 3},
                            new CreateProjectItem{StartDate = "9/5/2019", EndDate = "11/5/2019", Credits= 4}
                        }
                    
                    },
                    new CreateProject { FirstName = "Andres", LastName = "Mata" }
                );
        }
    }
}
