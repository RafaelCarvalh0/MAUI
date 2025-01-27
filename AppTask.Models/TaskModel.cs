namespace AppTask.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime PrevisionDate { get; set; }
        public bool IsCompleted { get; set; }
        public required List<SubTaskModel> SubTasks { get; set; }

        public class SubTaskModel 
        {
            public int Id { get; set; }
            public required string Name { get; set; }
            public bool IsCompleted { get; set; }
        }
    }
}
