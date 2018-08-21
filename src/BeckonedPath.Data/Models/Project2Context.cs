using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BeckonedPath.Data.Models
{
    public partial class Project2Context : DbContext
    {
        public virtual DbSet<EventComments> EventComments { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        public IConfiguration Configuration { get; set; }

        public Project2Context() //IConfiguration configuration
        {
            var builder = new ConfigurationBuilder();
            Configuration = builder.AddJsonFile(@"appsettings.dev.json").Build();
            //Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventComments>(entity =>
            {
                entity.HasKey(e => e.EventCommentId);

                entity.ToTable("EventComments", "P2BPath");

                entity.HasIndex(e => e.EventId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventComments)
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Events", "P2BPath");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EventDate).HasColumnType("datetime2(2)");

                entity.Property(e => e.Location).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Users", "P2BPath");

                entity.Property(e => e.FirstMidName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}
