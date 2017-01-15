using b_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace b_project.Data
{
    public class BlogDbContext : DbContext
    {
     
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        //public BlogDbContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=aspnet-b_project-cff60e48-0162-4c93-bd96-2a9926cb3bbd;Trusted_Connection=True;");
        //}
        //or
        // in Startup.cs ConfigureServices(IServiceCollection services) method(if you don't use Onconfiguring method in BlogDbContext class)
        //public void ConfigureServices(IServiceCollection services)
        //{
        // Add framework services.
        // services.AddMvc();
        //var connection = @"Server=(LocalDb)\MSSQLLocalDB;Database=Upload_Core;Trusted_Connection=True;";
        // services.AddDbContext<UploadDbContext>(options => options.UseSqlServer(connection));
        //}



        //public BlogDbContext(DbContextOptions<BlogDbContext> options)
        //    : base(options)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=aspnet-b_project-cff60e48-0162-4c93-bd96-2a9926cb3bbd;Trusted_Connection=True;");
        //}

        //public static BlogDbContext Create()
        //{
        //    return new BlogDbContext();
        //}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostVideo> PostVideos { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<ReplyLike> ReplyLikes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Reply>().ToTable("Reply");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<PostTag>().ToTable("PostTag");
            modelBuilder.Entity<PostCategory>().ToTable("PostCategory");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<PostVideo>().ToTable("PostVideo");
            modelBuilder.Entity<PostLike>().ToTable("PostLike");
            modelBuilder.Entity<CommentLike>().ToTable("CommentLike");
            modelBuilder.Entity<ReplyLike>().ToTable("ReplyLike");

            modelBuilder.Entity<PostCategory>().HasKey(c => new { c.PostId, c.CategoryId });
            modelBuilder.Entity<PostTag>().HasKey(c => new { c.PostId, c.TagId });
        }
    }
 }
