namespace specification_pattern.Domain.Specs.StudentSpecs
{
    public class ActiveStudentSpec : BaseSpec<Student>
    {        
        public ActiveStudentSpec(Status studentStatus, int page, int pageSize) : base(x => x.Status == studentStatus)
        {
            AddPaging(page, pageSize);            
            AddSortByDescendingExpression(x => x.FullName);            
        }
    }

    
}
