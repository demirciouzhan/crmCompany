using Microsoft.EntityFrameworkCore;

namespace crmCompany.Models
{
    public class companyContext : DbContext
    {

        public companyContext(DbContextOptions<companyContext> options) : base(options)
        {

        }

        public companyContext() { }
        public DbSet<Companys> Companies { get; set; }

        public DbSet<Services> Service  {get; set;}

        public DbSet<Services_Type> Service_Type { get; set; }
        public DbSet<Services_Details> Services_Details { get; set; }
    }
}
