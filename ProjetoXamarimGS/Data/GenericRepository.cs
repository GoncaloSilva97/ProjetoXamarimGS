using Microsoft.EntityFrameworkCore;
using ProjetoXamarimGS.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoXamarimGS.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        //public IQueryable<T> GetAll()
        //{
        //    return _context.Set<T>().AsNoTracking();
        //}







    }
}
