using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudent(int id);
        
        Task AddStudent(Student student);

        Task UpdateStudent(Student student);
        
        Task RemoveStudent(int id);
    }
}