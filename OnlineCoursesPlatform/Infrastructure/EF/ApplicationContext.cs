using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;

namespace OnlineCoursesPlatform.Infrastructure.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<CourseCategory> Categories { get; set; } = null!;
        public DbSet<CourseProgress> Progresses { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("D:\\coursWPF\\OnlineCoursesPlatform\\OnlineCoursesPlatform\\appsettings.json")
                    .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Users)
            .UsingEntity(j => j.ToTable("UserCourse"));

            

            modelBuilder.Entity<Course>()
                   .HasMany(c => c.Steps)
                   .WithOne(cs => cs.Course)
                   .HasForeignKey(cs => cs.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                   .HasMany(c => c.CourseProgresses)
                   .WithOne(cs => cs.Course)
                   .HasForeignKey(cs => cs.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);


            /*modelBuilder.Entity<Course>()
                   .HasMany(c => c.Comments)
                   .WithOne(cs => cs.)
                   .HasForeignKey(cs => cs.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
*/

            modelBuilder.Entity<Course>()
         .HasOne(c => c.Category)
         .WithMany()
         .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CourseProgress>()
         .HasOne(c => c.User)
         .WithMany()
         .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CourseProgress>()
         .HasOne(c => c.Course)
         .WithMany()
         .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Permission>()
        .HasOne(c => c.User)
        .WithMany()
        .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Permission>()
         .HasOne(c => c.Course)
         .WithMany()
         .HasForeignKey(c => c.CourseId);


            var user = new User
            {
                Id = 1,
                UserName = "marta",
                Password = "marta",
                Role = Roles.admin
            };
            modelBuilder.Entity<User>().HasData(user);


            var cats = new ObservableCollection<CourseCategory>()
            {
                new CourseCategory(){Id = 1, Name = "IT", IsSelected = false},
                new CourseCategory(){Id = 2, Name = "Nature", IsSelected=false}
            };


           /* var courses = new ObservableCollection<Course>
    {

        new Course
        {
            Id = 1,
            Name = "Machine Learning",
            CategoryId = 1,
            Description = "In the heart of the enchanted forest, where the ancient trees whispered secrets of centuries past, a young adventurer embarked on a journey of self-discovery.",
            Author = "Admin",
            Complexity = Complexity.easy,
           // Установите остальные свойства курса
        },
        new Course
        {
            Id = 2,
            Name = "Artificial Intelligence",
           CategoryId = 1,
            Description = "The path ahead was winding and mysterious, adorned with vibrant wildflowers that painted the landscape in a kaleidoscope of colors. The air was filled with the sweet scent of blooming jasmine.",
            Author = "Admin",
            Complexity = Complexity.high
            // Установите остальные свойства курса
        },new Course
        {
            Id = 3,
            Name = "Chemistry",
            CategoryId = 2,
            Description = "In the heart of the enchanted forest, where the ancient trees whispered secrets of centuries past, a young adventurer embarked on a journey of self-discovery.",
            Author = "Admin",
            Complexity = Complexity.easy
            // Установите остальные свойства курса
        },
        new Course
        {
            Id = 4,
            Name = "Math",
            CategoryId = 2,
            Description = "In the heart of the enchanted forest, where the ancient trees whispered secrets of centuries past, a young adventurer embarked on a journey of self-discovery.",
            Author = "Admin",
            Complexity = Complexity.medium
            // Установите остальные свойства курса
        },
        new Course
        {
            Id = 5,
            Name = "UI/UX Design",
           CategoryId = 1,
            Description = "The path ahead was winding and mysterious, adorned with vibrant wildflowers that painted the landscape in a kaleidoscope of colors. The air was filled with the sweet scent of blooming jasmine.",
            Author = "Admin",
            Complexity = Complexity.medium,
            IsOpen = false
            // Установите остальные свойства курса
        },
        new Course
        {
            Id = 6,
            Name = "C# .NET",
            CategoryId = 1,
            Description = "In the heart of the enchanted forest, where the ancient trees whispered secrets of centuries past, a young adventurer embarked on a journey of self-discovery.",
            Author = "Admin",
            Complexity = Complexity.high
            // Установите остальные свойства курса
        }
        };*/

            modelBuilder.Entity<CourseCategory>().HasData(cats);
            //modelBuilder.Entity<Course>().HasData(courses);

            /*var permissions = new ObservableCollection<Permission>()
            {
                new Permission { Id = 1, CourseId = 1, State = PermissionState.open, UserId = 1 },
                new Permission { Id = 2, CourseId = 2, State = PermissionState.open, UserId = 1 },
                new Permission { Id = 3, CourseId = 3, State = PermissionState.open, UserId = 1 },
                new Permission { Id = 4, CourseId = 4, State = PermissionState.close, UserId = 1 },
                new Permission { Id = 5, CourseId = 5, State = PermissionState.close, UserId = 1 },
                new Permission { Id = 6, CourseId = 6, State = PermissionState.open, UserId = 1 }
            };
            modelBuilder.Entity<Permission>().HasData(permissions);*/
        }
    }
}
