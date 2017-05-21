
using System;
using Microsoft.EntityFrameworkCore;

namespace  DotnetcoreWebapiAng.Models
{
    public class BloggingContext: DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Group> Groups {get; set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=Test.db");
        }
    }

    public class Group
    {
        public Int32 Id {get; set;}
        public String Name {get; set;}
    }

    public class User
    {
        public Int32 Id {get; set;}
        public String UserName {get; set;}
        public String Password {get; set;}
    }
}