using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.services.StudentServices
{
    public interface IStudentServices
    {
        Task<bool> AddStudentAsync(object o);
        Task<bool> UpdateStudentAsync(string num);
        Task<List<Student>> GetStudentListAsync(int className);
        Task<bool> DeleteStudentOrUpdateState(string guid);
    }
}
