
using System;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace  DotnetcoreWebapiAng.Models
{
    public class BloggingContext: DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Group> Groups {get; set;}

        public BloggingContext(DbContextOptions<BloggingContext> options):base(options)
        {

        }

        //protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder){
        //    optionsBuilder.UseSqlite("Data Source=Test.db");
        //}
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