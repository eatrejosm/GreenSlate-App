using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSlateApp.Model
{
    public class CreateProject : IObjectWithState
    {
        public CreateProject()
        {
            CreateProjectItems = new List<CreateProjectItem>();
        }

        [Key]
        public int ProjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ObjectState ObjectState { get; set; }

        public virtual List<CreateProjectItem> CreateProjectItems { get; set; }


    }
}
