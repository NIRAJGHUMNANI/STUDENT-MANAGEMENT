using StudentManagementRestAPI.Models;
using System.Collections.Concurrent;

namespace StudentManagementRestAPI.Services;

public class StudentService : IStudentService
{
    private readonly ConcurrentDictionary<int, Student> _students = new();
    private int _nextId = 0;

    public StudentService()
    {
        Add(new Student { Name = "Aarav Patel", Email = "aarav@example.com", Course = "CSE", Semester = 2 });
        Add(new Student { Name = "Diya Shah", Email = "diya@example.com", Course = "AI/ML", Semester = 3 });
    }

    public IEnumerable<Student> GetAll() => _students.Values.OrderBy(s => s.Id);

    public Student? GetById(int id) => _students.TryGetValue(id, out var student) ? student : null;

    public Student Add(Student student)
    {
        var newStudent = new Student
        {
            Id = Interlocked.Increment(ref _nextId),
            Name = student.Name,
            Email = student.Email,
            Course = student.Course,
            Semester = student.Semester
        };
        _students[newStudent.Id] = newStudent;
        return newStudent;
    }

    public bool Update(int id, Student student)
    {
        if (!_students.ContainsKey(id)) return false;
        _students[id] = new Student
        {
            Id = id,
            Name = student.Name,
            Email = student.Email,
            Course = student.Course,
            Semester = student.Semester
        };
        return true;
    }

    public bool Delete(int id) => _students.TryRemove(id, out _);
}
