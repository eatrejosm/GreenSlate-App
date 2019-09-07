using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GreenSlateApp.Model;

namespace GreenSlateApp.Web.ViewModels
{
    public class CreateProjectViewModel :IObjectWithState
    {

        public CreateProjectViewModel()
        {
            CreateProjectItems = new List<CreateProjectItemViewModel>();
            CreateProjectItemsToDelete = new List<int>();
        }

        [Key]
        public int ProjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserFlag { get; set; }

        public ObjectState ObjectState { get; set; }

        public  List<CreateProjectItemViewModel> CreateProjectItems { get; set; }

        public List<int> CreateProjectItemsToDelete { get; set; }


    }
}