using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Models
{
    public class InsuranceDetailContext : DbContext
    {
        public InsuranceDetailContext(DbContextOptions<InsuranceDetailContext> options) : base(options) 
        { 
        
        }

        public DbSet<InsuranceDetail> InsuranceDetails { get; set; }
    }
}
