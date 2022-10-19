using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutPoint.Application.Interfaces;
using OutPoint.Domain.Entities;

namespace OutPoint.Persistence.Context;

public class OutPointIdentityDbContext : IdentityDbContext<ApiUser>, IOutPointIdentityDbContext
{
    public OutPointIdentityDbContext(DbContextOptions<OutPointIdentityDbContext> options) : base(options)
    {
    }
    
    public DbSet<ApiUser> ApiUsers { get; set; }
}