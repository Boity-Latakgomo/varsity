using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using varsity.Authorization.Roles;
using varsity.Authorization.Users;
using varsity.MultiTenancy;
using varsity.Domain;

namespace varsity.EntityFrameworkCore
{
    public class varsityDbContext : AbpZeroDbContext<Tenant, Role, User, varsityDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> ARFPersons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }  
        public DbSet<Module> Modules { get; set; }
        public DbSet<LecturerModule> LecturersModules { get; set; }
        public DbSet<ModuleStudent> ModuleStudents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerQ> AnswerQs { get; set; }
        public DbSet<Rating> Ratings { get; set; }   
        public DbSet<Bookmark> BookMarks { get; set; }  


        
        public varsityDbContext(DbContextOptions<varsityDbContext> options)
            : base(options)
        {
              
        }
    }
}
