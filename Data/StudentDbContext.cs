using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Domain;
using System.Collections.Generic;

namespace StudentManagement.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        //Table name
        public DbSet<StudentModel> Students { get; set; }
    }
}
