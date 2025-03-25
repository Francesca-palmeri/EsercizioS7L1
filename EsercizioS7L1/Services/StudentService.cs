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

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            try
            {
                return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            try
            {
                var existingStudent = await GetStudentByIdAsync(id);
                if (existingStudent == null)
                {
                    return false;
                }
                _context.Students.Remove(existingStudent);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
