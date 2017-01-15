using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using b_project.Data;

namespace b_project.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("b_project.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Checked");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UrlSeo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("b_project.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("Deleted");

                    b.Property<int>("LikeCount");

                    b.Property<string>("PostId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("b_project.Models.CommentLike", b =>
                {
                    b.Property<string>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentId1");

                    b.Property<bool>("Dislike");

                    b.Property<bool>("Like");

                    b.Property<string>("Username");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentId1");

                    b.ToTable("CommentLike");
                });

            modelBuilder.Entity("b_project.Models.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int>("LikeCount");

                    b.Property<string>("Meta")
                        .IsRequired();

                    b.Property<DateTime?>("Modified");

                    b.Property<DateTime>("PostedOn");

                    b.Property<bool>("Published");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UrlSeo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("b_project.Models.PostCategory", b =>
                {
                    b.Property<string>("PostId");

                    b.Property<string>("CategoryId");

                    b.Property<bool>("Checked");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategory");
                });

            modelBuilder.Entity("b_project.Models.PostLike", b =>
                {
                    b.Property<string>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Dislike");

                    b.Property<bool>("Like");

                    b.Property<string>("PostId1");

                    b.Property<string>("Username");

                    b.HasKey("PostId");

                    b.HasIndex("PostId1");

                    b.ToTable("PostLike");
                });

            modelBuilder.Entity("b_project.Models.PostTag", b =>
                {
                    b.Property<string>("PostId");

                    b.Property<string>("TagId");

                    b.Property<bool>("Checked");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("b_project.Models.PostVideo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PostId");

                    b.Property<string>("VideoSiteName");

                    b.Property<string>("VideoThumbnail");

                    b.Property<string>("VideoUrl")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostVideo");
                });

            modelBuilder.Entity("b_project.Models.Reply", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<string>("CommentId");

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ParentReplyId");

                    b.Property<string>("PostId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("b_project.Models.ReplyLike", b =>
                {
                    b.Property<string>("ReplyId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Dislike");

                    b.Property<bool>("Like");

                    b.Property<string>("ReplyId1");

                    b.Property<string>("Username");

                    b.HasKey("ReplyId");

                    b.HasIndex("ReplyId1");

                    b.ToTable("ReplyLike");
                });

            modelBuilder.Entity("b_project.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Checked");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UrlSeo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("b_project.Models.Comment", b =>
                {
                    b.HasOne("b_project.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("b_project.Models.CommentLike", b =>
                {
                    b.HasOne("b_project.Models.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId1");
                });

            modelBuilder.Entity("b_project.Models.PostCategory", b =>
                {
                    b.HasOne("b_project.Models.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("b_project.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("b_project.Models.PostLike", b =>
                {
                    b.HasOne("b_project.Models.Post", "Post")
                        .WithMany("PostLikes")
                        .HasForeignKey("PostId1");
                });

            modelBuilder.Entity("b_project.Models.PostTag", b =>
                {
                    b.HasOne("b_project.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("b_project.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("b_project.Models.PostVideo", b =>
                {
                    b.HasOne("b_project.Models.Post", "Post")
                        .WithMany("PostVideos")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("b_project.Models.Reply", b =>
                {
                    b.HasOne("b_project.Models.Comment", "Comment")
                        .WithMany("Replies")
                        .HasForeignKey("CommentId");

                    b.HasOne("b_project.Models.Post", "Post")
                        .WithMany("Replies")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("b_project.Models.ReplyLike", b =>
                {
                    b.HasOne("b_project.Models.Reply", "Reply")
                        .WithMany("ReplyLikes")
                        .HasForeignKey("ReplyId1");
                });
        }
    }
}
