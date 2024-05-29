using FileProvider.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileProvider.Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<FileEntity> AspNetFiles { get; set; }
}
