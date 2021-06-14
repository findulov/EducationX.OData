namespace EducationX.Domain.Entities
{
    public class AcademicRank
    {
        public AcademicRank(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
