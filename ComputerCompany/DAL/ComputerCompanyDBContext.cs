using Microsoft.EntityFrameworkCore;
using ComputerCompany.Models;

namespace ComputerCompany.DAL
{
    public class ComputerCompanyDBContext : DbContext
    {
        public ComputerCompanyDBContext(DbContextOptions<ComputerCompanyDBContext> options)
            : base(options)
        { }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Client> Clients { get; set; }
    }
}