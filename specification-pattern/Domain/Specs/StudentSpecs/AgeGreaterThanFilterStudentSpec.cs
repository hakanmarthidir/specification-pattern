namespace specification_pattern.Domain.Specs.StudentSpecs
{
    public class AgeGreaterThanFilterStudentSpec : BaseSpec<Student>
    {
        public AgeGreaterThanFilterStudentSpec(int ageLimit) : base(x => (DateTime.Now.Year - x.BirthDate.Year) > ageLimit && x.Status == Status.Active)
        {
            AddSortByExpression(x => x.BirthDate);
        }
    }
}
