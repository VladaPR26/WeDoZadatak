using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WorkoutTracker.DAL.Entities.Trainings;
using WorkoutTracker.DAL.Entities.Users;


namespace WorkoutTracker.DAL.DatabaseClient.Migrations;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Training> Trainings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Training>()
            .Property(t => t.Exercise)
            .HasConversion(
                v => v.ToString(),
                v => (ExerciseType)Enum.Parse(typeof(ExerciseType), v));
    }
}
