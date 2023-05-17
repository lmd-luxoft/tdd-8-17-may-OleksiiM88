namespace TaskManagementService.DA.Interfaces.DTO
{
    public class DataTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string[] Comments { get; set; }
    }
}