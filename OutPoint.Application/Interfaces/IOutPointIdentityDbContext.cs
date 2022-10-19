using Microsoft.EntityFrameworkCore;
using OutPoint.Domain.Entities;

namespace OutPoint.Application.Interfaces;

public interface IOutPointIdentityDbContext
{
    DbSet<ApiUser> ApiUsers { get; set; }
}