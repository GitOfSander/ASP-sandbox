using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

namespace ASP_Sandbox.Entities;

public class SandboxContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }

    public SandboxContext(DbContextOptions<SandboxContext> options) : base(options)
    {

    }
}