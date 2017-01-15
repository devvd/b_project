using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace b_project.Models
{
    public class Post
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        //A short description to display in the view of blog list
        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [Display(Name = "Body")]
        public string Body { get; set; }
        //Meta is used in the head section of html
        [Required]
        [Display(Name = "Meta")]
        public string Meta { get; set; }
        //This is used for the Url Slug to make the Urls client-friendly 
        [Required]
        [Display(Name = "UrlSeo")]
        public string UrlSeo { get; set; }
        //Boolean to check if post has published
        public bool Published { get; set; }
        //Shows how many Likes a post has
        [DefaultValue(0)]
        public int LikeCount { get; set; }
        //Displays when a post was created
        public DateTime PostedOn { get; set; }
        //Displays when a post was edited
        public DateTime? Modified { get; set; }

        //Navigation Properties
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public ICollection<PostVideo> PostVideos { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
    }
    public class Category
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "UrlSeo")]
        public string UrlSeo { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public bool Checked { get; set; }

        //Navigation Properties
        public ICollection<PostCategory> PostCategories { get; set; }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////// This is throwing a primary key error because .netcore doesn't allow column order with the [Key] attribute above it. Find out how to composite key in .netcore
    /// </summary>
    public class PostCategory
    {
        //Using a composite key

        //Column order no longer available(ordering columns by class property). Need to manually change generated migration file
        public string PostId { get; set; }
        //Column order no longer available
        public string CategoryId { get; set; }
        public bool Checked { get; set; }

        //Navigation Properties
        public Post Post { get; set; }
        public Category Category { get; set; }
    }

    public class Comment
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Body { get; set; }
        [DefaultValue(0)]
        public int LikeCount { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Navigation Properties
        public Post Post { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
    }

    public class Reply
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string ParentReplyId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Body { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Navigation Properties
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public ICollection<ReplyLike> ReplyLikes { get; set; }
    }

    public class Tag
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "UrlSeo")]
        public string UrlSeo { get; set; }

        //Navigation Properties
        public bool Checked { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }

    public class PostTag
    {
        //Using Composite key

        //Column order no longer available
        public string PostId { get; set; }

        //Column order no longer available
        public string TagId { get; set; }
        public bool Checked { get; set; }

        //Navigation Properties
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }

    public class PostVideo
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "VideoUrl")]
        public string VideoUrl { get; set; }
        public string VideoThumbnail { get; set; }
        public string PostId { get; set; }
        public string VideoSiteName { get; set; }

        //Navigation Property
        public Post Post { get; set; }
    }

    public class PostLike
    {
        [Key]
        public string PostId { get; set; }
        public string Username { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }

        //Navigation Property
        public Post Post { get; set; }
    }

    public class CommentLike
    {
        [Key]
        public string CommentId { get; set; }
        public string Username { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }

        //Navigation Property
        public Comment Comment { get; set; }
    }

    public class ReplyLike
    {
        [Key]
        public string ReplyId { get; set; }
        public string Username { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }

        //Navigation Property
        public Reply Reply { get; set; }
    }



    //Viewmodel used in the index and post views
    public class BlogViewModel
    {
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public IList<Tag> Tag { get; set; }
        public int PostDislikes { get; set; }
        public int PostLikes { get; set; }
        public int TotalPosts { get; set; }
        public List<string> Category { get; set; }
        public Post Post { get; set; }
        public string ID { get; set; }
        public string ShortDescription { get; set; }
        public string Title { get; set; }
        public IList<Category> PostCategories { get; set; }
        public IList<Tag> PostTags { get; set; }
        public string UrlSlug { get; set; }
    }

    public class AllPostsViewModel
    {

    }
}
