using LazyLoading.Models;

namespace LazyLoading.Services
{
    internal static class SubjectService
    {
        internal static Lazy<List<Subject>> GetAllSubjects()
        {
            var subjects = new Lazy<List<Subject>>();

            subjects.Value.Add(new Subject() { Id = 1, Name = "jhon"});
            subjects.Value.Add(new Subject() { Id = 2, Name = "charly" });

            return subjects;
        }
    }
}
