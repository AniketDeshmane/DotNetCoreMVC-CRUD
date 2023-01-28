namespace StudentManagement.Models
{
    public class UpdateStudentModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Class { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
