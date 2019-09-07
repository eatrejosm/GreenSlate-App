using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenSlateApp.DataLayer;
using GreenSlateApp.Model;
using GreenSlateApp.Web.ViewModels;

namespace GreenSlateApp.Web.Controllers
{
    public class CreateProjectsController : Controller
    {
        private ProjectContext db;


        public CreateProjectsController()
        {
            db = new ProjectContext();
        }


        public ActionResult Index()
        {
            return View(db.CreateProjects.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject createProject = db.CreateProjects.Find(id);
            if (createProject == null)
            {
                return HttpNotFound();
            }


            CreateProjectViewModel createProjectViewModel = ViewModels.Helpers.CreateProjectViewModelFromCreateProject(createProject);
            createProjectViewModel.UserFlag = "view model works";
            return View(createProjectViewModel);
        }


        public ActionResult Create()
        {
            CreateProjectViewModel createProjectViewModel = new CreateProjectViewModel();
            createProjectViewModel.ObjectState = ObjectState.Added;
            return View(createProjectViewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject createProject = db.CreateProjects.Find(id);
            if (createProject == null)
            {
                return HttpNotFound();
            }

            CreateProjectViewModel createProjectViewModel = ViewModels.Helpers.CreateProjectViewModelFromCreateProject(createProject);
            createProjectViewModel.UserFlag = string.Format("The previous name for user was {0}", createProjectViewModel.FirstName);

            return View(createProjectViewModel);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject createProject = db.CreateProjects.Find(id);
            if (createProject == null)
            {
                return HttpNotFound();
            }

            CreateProjectViewModel createProjectViewModel = ViewModels.Helpers.CreateProjectViewModelFromCreateProject(createProject);
            createProjectViewModel.UserFlag = "Deleting user";
            createProjectViewModel.ObjectState = ObjectState.Deleted;

            return View(createProjectViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult Save(CreateProjectViewModel createProjectViewModel)
        {
            CreateProject createProject = ViewModels.Helpers.CreateProjectFromCreateProjectViewModel(createProjectViewModel);

            db.CreateProjects.Attach(createProject);

 
                foreach (CreateProjectItemViewModel createProjectItemViewModel in createProjectViewModel.CreateProjectItems)
                {
                    CreateProjectItem createProjectItem = db.CreateProjectItems.Find(createProjectItemViewModel.ProjectItemId);
                    if (createProjectItem != null)
                        createProjectItem.ObjectState = ObjectState.Deleted;
                }
      

                foreach (int projectItemId in createProjectViewModel.CreateProjectItemsToDelete)
                {
                    CreateProjectItem createProjectItem = db.CreateProjectItems.Find(projectItemId);
                    if (createProjectItem != null)
                        createProjectItem.ObjectState = ObjectState.Deleted;
                }
            

            db.SetNewStateObject();
            db.SaveChanges();

            if (createProject.ObjectState == ObjectState.Deleted)
                return Json(new { newLocation = "/CreateProjects/Index/" });

            string userFlag = ViewModels.Helpers.GetUserFlag(createProjectViewModel.ObjectState, createProject.FirstName);
            createProjectViewModel = ViewModels.Helpers.CreateProjectViewModelFromCreateProject(createProject);
            createProjectViewModel.UserFlag = userFlag;

            return Json(new { createProjectViewModel });

        }
    }
}
