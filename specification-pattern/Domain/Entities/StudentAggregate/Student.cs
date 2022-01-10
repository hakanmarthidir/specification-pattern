namespace specification_pattern.Domain
{
    public class Student  : BaseEntity
    {        
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }
    }
}
