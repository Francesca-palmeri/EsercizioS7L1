using EsercizioS7L1.Data;
using EsercizioS7L1.Models;
using Microsoft.EntityFrameworkCore;

namespace EsercizioS7L1.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CreateStudentAsync(Student student)
        {
            try
            {
                _context.Students.AddAsync(student);
               return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Student>?> GetStudentsAsync()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
