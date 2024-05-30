using Microsoft.EntityFrameworkCore;
using ModeloApi.Entities;

namespace ModeloApi.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contatos> Contatos { get; set; }
    }
}
