using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenSlateApp.Model;

namespace GreenSlateApp.Web.ViewModels
{
    public static class Helpers
    {

        public static CreateProjectViewModel CreateProjectViewModelFromCreateProject(CreateProject createProject)
        {
            CreateProjectViewModel createProjectViewModel = new CreateProjectViewModel();
            createProjectViewModel.ProjectId = createProject.ProjectId;
            createProjectViewModel.FirstName = createProject.FirstName;
            createProjectViewModel.LastName = createProject.LastName;
            createProjectViewModel.ObjectState = ObjectState.Unchanged;

            foreach (CreateProjectItem createProjectItem in createProject.CreateProjectItems)
            {
                CreateProjectItemViewModel createProjectItemViewModel = new CreateProjectItemViewModel();
                createProjectItemViewModel.ProjectItemId = createProjectItem.ProjectItemId;
                createProjectItemViewModel.StartDate = createProjectItem.StartDate;
                createProjectItemViewModel.EndDate = createProjectItem.EndDate;
                createProjectItemViewModel.Credits = createProjectItem.Credits;

                createProjectItemViewModel.ObjectState = ObjectState.Unchanged;

                createProjectItem.ProjectId = createProjectItemViewModel.ProjectId;
                createProjectViewModel.CreateProjectItems.Add(createProjectItemViewModel);
            }

            return createProjectViewModel;
        }

        public static CreateProject CreateProjectFromCreateProjectViewModel(CreateProjectViewModel createProjectViewModel)
        {
            CreateProject createProject = new CreateProject();
            createProject.ProjectId = createProjectViewModel.ProjectId;
            createProject.FirstName = createProjectViewModel.FirstName;
            createProject.LastName = createProjectViewModel.LastName;
            createProject.ObjectState = createProjectViewModel.ObjectState;

            int tmpProjectItemId = -1;

            foreach (CreateProjectItemViewModel createProjectItemViewModel in createProjectViewModel.CreateProjectItems)
            {
                CreateProjectItem createProjectItem = new CreateProjectItem();
                createProjectItem.StartDate = createProjectItemViewModel.StartDate;
                createProjectItem.EndDate = createProjectItemViewModel.EndDate;
                createProjectItem.Credits = createProjectItemViewModel.Credits;
                createProjectItem.ObjectState = createProjectItemViewModel.ObjectState;

                if (createProjectItemViewModel.ObjectState != ObjectState.Added)
                    createProjectItem.ProjectItemId = createProjectItemViewModel.ProjectItemId;
                else
                {
                    createProjectItem.ProjectItemId = tmpProjectItemId;
                    tmpProjectItemId--;
                }

                createProjectItem.ProjectId = createProjectViewModel.ProjectId;

                createProject.CreateProjectItems.Add(createProjectItem);
            }

            return createProject;
        }

        public static string GetUserFlag(ObjectState objectState, string firstName)
        {

            string userFlag = string.Empty;
  
            switch (objectState)
            {

                case ObjectState.Added:
                    userFlag = string.Format("{0}'s Project Created", firstName);
                    break;

                case ObjectState.Modified:
                    userFlag = string.Format("User has been updated to {0}", firstName);
                    break;

            }
            return userFlag;
        }
    }
}