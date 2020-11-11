using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StudentsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<List<Student>> GetStudents()
        {
            return await _databaseContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _databaseContext.Students.SingleOrDefaultAsync(x => x.Id == id);

            return student;
        }

        public async Task AddStudent(Student student)
        {
            await _databaseContext.AddAsync(student);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _databaseContext.Update(student);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task RemoveStudent(int id)
        {
            var deletingEntity = await _databaseContext.Students.SingleOrDefaultAsync(x => x.Id == id);
            if (deletingEntity != null)
            {
                _databaseContext.Remove(deletingEntity);
            }

            await _databaseContext.SaveChangesAsync();
        }
    }
}