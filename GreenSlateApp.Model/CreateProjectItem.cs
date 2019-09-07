using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSlateApp.Model
{
    public class CreateProjectItem : IObjectWithState
    {

        [Key]
        public int ProjectItemId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int Credits { get; set; }

        
        public int ProjectId { get; set; }
        public CreateProject Createproject { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}
