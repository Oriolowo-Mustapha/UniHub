using Microsoft.EntityFrameworkCore;
using UniHub.Entities;

namespace UniHub.UniHubDbContext;

public class UniHubContext : DbContext
{
	public UniHubContext(DbContextOptions<UniHubContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// User - Post Relationship (One-to-Many)
		modelBuilder.Entity<Posts>()
			.HasOne(p => p.User)
			.WithMany(u => u.Posts)
			.HasForeignKey(p => p.UserID);

		// Post - Comments Relationship (One-to-Many)
		modelBuilder.Entity<Comments>()
			.HasOne(c => c.Posts)
			.WithMany(p => p.Comments)
			.HasForeignKey(c => c.PostID);

		// User - Likes Relationship (One-to-Many)
		modelBuilder.Entity<Likes>()
			.HasOne(l => l.User)
			.WithMany(u => u.Likes)
			.HasForeignKey(l => l.UserID);

		// Post - Likes Relationship (One-to-Many)
		modelBuilder.Entity<Likes>()
			.HasOne(l => l.Posts)
			.WithMany(p => p.Likes)
			.HasForeignKey(l => l.PostId);

		// User - Reposts Relationship (One-to-Many)
		modelBuilder.Entity<Repost>()
			.HasOne(r => r.User)
			.WithMany(u => u.Reposts)
			.HasForeignKey(r => r.RepostUserID);

		// Post - Reposts Relationship (One-to-Many)
		modelBuilder.Entity<Repost>()
			.HasOne(r => r.Posts)
			.WithMany(p => p.Reposts)
			.HasForeignKey(r => r.OriginalPostID);

		// Club - User Relationship (One-to-Many)
		modelBuilder.Entity<Club>()
			.HasMany(c => c.Users)
			.WithMany(u => u.Clubs);

		// Events - User Relationship (Many-to-Many)
		modelBuilder.Entity<Events>()
			.HasMany(e => e.Attendees)
			.WithMany(u => u.Events);

		// Notification - User Relationship (One-to-Many)
		modelBuilder.Entity<Notifications>()
				.HasOne(n => n.User)
				.WithMany(u => u.Notifications)
				.HasForeignKey(n => n.UserId);

		// Followers - User Relationship (Many-to-Many)
		modelBuilder.Entity<UserFollow>()
			.HasMany(uf => uf.Followers)
			.WithMany(u => u.Followers);

	}

	public DbSet<User> Users { get; set; }
	public DbSet<Posts> Posts { get; set; }
	public DbSet<Comments> Comments { get; set; }
	public DbSet<Likes> Likes { get; set; }
	public DbSet<Repost> Reposts { get; set; }
	public DbSet<Club> Clubs { get; set; }
	public DbSet<Events> Events { get; set; }
	public DbSet<Notifications> Notifications { get; set; }
	public DbSet<UserFollow> UserFollows { get; set; }
}