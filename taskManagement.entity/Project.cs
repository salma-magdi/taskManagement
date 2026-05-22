namespace taskManagement.entity
{
    public class Project:BaseClass
    {

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        //fk 
        public int UserId { get; set; }
       
        // navigation properity 
        public User User { get; set; }
        public List<TaskItem> task { get; set; } = new List<TaskItem>();

    }
}
