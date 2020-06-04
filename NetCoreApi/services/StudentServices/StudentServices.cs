using Microsoft.EntityFrameworkCore;
using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.services.StudentServices
{
    public class StudentServices : ServicesBase<Student>, IStudentServices
    {
        private readonly ServicesBase<Student> _servicesBase;
        public StudentServices(DataBaseContent dataBaseContent, ServicesBase<Student> servicesBase) : base(dataBaseContent)
        {
            _servicesBase = servicesBase;
        }

        public async Task<bool> AddStudentAsync(object o)
        {
            return false; //await _dataBaseContent.AddAsync(o).SaveChangesAsync() > 0 ? true : false;
        }

        public Task<bool> DeleteStudentOrUpdateState(string guid)
        {
            return null;
        }

        public async Task<List<Student>> GetStudentListAsync(int classId)
        {
            var query = await (from b in _dataBaseContent.student
                               where b.ClassID == classId
                               select b).ToListAsync();
            return query;
        }

        public async Task<bool> UpdateStudentAsync(string num)
        {
            var date = await _servicesBase.GetByIdAsync(num);
            _dataBaseContent.Remove(date);
            return await _dataBaseContent.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
