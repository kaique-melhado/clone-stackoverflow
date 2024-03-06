using Microsoft.EntityFrameworkCore;
using CloneStackOverflow.Models;

namespace CloneStackOverflow.Data
{
    public class CloneStackOverflowContext : DbContext
    {
        public CloneStackOverflowContext(DbContextOptions<CloneStackOverflowContext> opts) : base(opts)
        {

        }
    }
}
