using Microsoft.EntityFrameworkCore;
using WidgetApi.Models;

namespace WidgetApi.Data
{
    public class WidgetContext : DbContext
    {
        public WidgetContext(DbContextOptions<WidgetContext> options) : base(options)
        {
        }

        public DbSet<Widget> Widgets { get; set; }
    }
}
