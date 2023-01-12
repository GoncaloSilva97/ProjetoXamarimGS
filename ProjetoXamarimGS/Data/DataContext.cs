using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoXamarimGS.Data.Entities;
using System.Linq;

namespace ProjetoXamarimGS.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //public DbSet<User> Useres { get; set; }







    }
}
