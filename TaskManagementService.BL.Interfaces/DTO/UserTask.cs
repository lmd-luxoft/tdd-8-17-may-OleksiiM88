namespace TaskManagementService.BL.Interfaces.DTO
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string[] Comments { get; set; }
    }
}