namespace smSystem.Models
{
    public class School
    {
        public string SchoolId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Student> students { get; set; } = new List<Student>();
    }
}