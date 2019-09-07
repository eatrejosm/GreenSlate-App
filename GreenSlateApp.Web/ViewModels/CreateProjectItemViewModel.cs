using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GreenSlateApp.Model;

namespace GreenSlateApp.Web.ViewModels
{
    public class CreateProjectItemViewModel : IObjectWithState
    {
        [Key]
        public int ProjectItemId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Credits { get; set; }
        public int ProjectId { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}