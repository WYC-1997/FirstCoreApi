using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.services
{
    public abstract class ServicesBase<T> where T : class
    {
        protected readonly DataBaseContent _dataBaseContent;
        protected readonly DbSet<T> Tb;
        protected ServicesBase(DataBaseContent dataBaseContent)
        {
            _dataBaseContent = dataBaseContent;
            Tb = _dataBaseContent.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await Tb.FindAsync(id);
        }
    }
}

