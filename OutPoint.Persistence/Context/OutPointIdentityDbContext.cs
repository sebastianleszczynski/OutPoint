using Microsoft.AspNetCore.Identity;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "28d70a89-2149-47cc-bd78-55d82d406fcd"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "ab195862-9152-4976-8958-a5c74a8f858d"
            });

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "3fea5c15-07c5-4d8e-bc99-a9eb44a57edb",
                Email = "user@outpoint.com",
                NormalizedEmail = "USER@OUTPOINT.COM",
                UserName = "User",
                NormalizedUserName = "USER@OUTPOINT.COM",
                PasswordHash = hasher.HashPassword(null!, "Start123!")
            },
            new ApiUser
            {
                Id = "a14b986b-da6c-42a1-9c17-5b0df26f28dd",
                Email = "admin@outpoint.com",
                NormalizedEmail = "ADMIN@OUTPOINT.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN@OUTPOINT.COM",
                PasswordHash = hasher.HashPassword(null!, "Start123!")
            });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "28d70a89-2149-47cc-bd78-55d82d406fcd",
                UserId = "3fea5c15-07c5-4d8e-bc99-a9eb44a57edb"
            },
            new IdentityUserRole<string>
            {
                RoleId = "ab195862-9152-4976-8958-a5c74a8f858d",
                UserId = "a14b986b-da6c-42a1-9c17-5b0df26f28dd"
            });
    }
}