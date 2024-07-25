using Microsoft.EntityFrameworkCore;
using RealTimeChatTask.DAL.Entities;

namespace RealTimeChatTask.DAL.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<Message> Messages { get; set; }
}