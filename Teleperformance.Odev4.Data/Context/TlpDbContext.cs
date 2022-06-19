using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teleperformance.Odev4.Entity;

namespace Teleperformance.Odev4.Data.Context
{
    public class TlpDbContext : IdentityDbContext<AppUser>
    {
        public TlpDbContext(DbContextOptions<TlpDbContext> options) : base(options)
        {


        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRequest> Requests { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMember { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageHistory> MessageHistory { get; set; }
        public DbSet<MessageSendType> MessageSendTypes { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}




