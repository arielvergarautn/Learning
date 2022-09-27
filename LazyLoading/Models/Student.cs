using LazyLoading.Services;

namespace LazyLoading.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Lazy<List<Subject>> SubjectsLazy => SubjectService.GetAllSubjects();
        public List<Subject> Subjects => SubjectService.GetAllSubjects().Value;
    }
}
