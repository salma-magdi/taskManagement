using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity.enums;

namespace taskManagement.entity
{
    public class TaskItem:BaseClass
    {
       
        public string Description { get; set; }
        public DateTime dueDate { get; set; }
        
        public taskStatus Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public int ProjectId { get; set; }
        //nav property 
        public Project Project { get; set; }


    }
}
