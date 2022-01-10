namespace specification_pattern.Domain.Specs.StudentSpecs
{
    public class ActiveStudentSpec : BaseSpec<Student>
    {        
        public ActiveStudentSpec(Status studentStatus) : base(x => x.Status == studentStatus)
        {
            AddSortByDescendingExpression(x => x.FullName);            
        }
    }
}
