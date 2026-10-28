using StudentManagementRestAPI.Models;

namespace StudentManagementRestAPI.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAll();
    Student? GetById(int id);
    Student Add(Student student);
    bool Update(int id, Student student);
    bool Delete(int id);
}
