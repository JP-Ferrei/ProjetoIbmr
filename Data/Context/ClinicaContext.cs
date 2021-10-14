using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ClinicaContext: DbContext
    {
        public ClinicaContext(DbContextOptions options) : base(options)
        {
        }
    }
}
