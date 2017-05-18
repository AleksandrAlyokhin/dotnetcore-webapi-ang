
using System;
using Microsoft.EntityFrameworkCore;

namespace  DotnetcoreWebapiAng.Models
{
    public class BloggingContext: DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=Test.db");
        }
    }

    public class Role
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public String Note {get; set;}
    }

    public class User
    {
        public Guid Id {get; set;}
        public String Loggin {get; set;}
        public String Name {get; set;}
    }
}