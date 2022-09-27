using LazyLoading.Models;

var student = new Student()
{
    Id = 1,
    Name = "Ariel",
    Age = 27
};

var subjects = student.Subjects;

var subjectsLazy = student.SubjectsLazy;
var aux = subjectsLazy.Value;