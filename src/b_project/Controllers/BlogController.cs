using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using b_project.DAL;
using Microsoft.AspNetCore.Authorization;
using b_project.Models;
using b_project.Data;

namespace b_project.Controllers
{
    public class BlogController : Controller
    {

        private IBlogRepository _blogRepository;

        //Creates a static list of posts I want to use in the view
        public static List<BlogViewModel> postList = new List<BlogViewModel>();


        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            Posts();
            return View();
        }

        //Clear the list every time I call the Posts action method. Prevents duplication if not present.
        //Get all of the posts
        //For each post, get all of the var's and add each them as a new BlogViewModel item to the list
        [ChildActionOnly]
        public ActionResult Posts()
        {
            postList.Clear();

            var posts = _blogRepository.GetPosts();
            foreach (var post in posts)
            {
            
                var postVideos = GetPostVideos(post);
                var postCategories = GetPostCategories(post);
                var postTags = GetPostTags(post);
                var likes = _blogRepository.LikeDislikeCount("postlike", post.Id);
                var dislikes = _blogRepository.LikeDislikeCount("postdislike", post.Id);
                postList.Add(new BlogViewModel() { Post = post, Modified = post.Modified, Title = post.Title, ShortDescription = post.ShortDescription, PostedOn = post.PostedOn, ID = post.Id, PostLikes = likes, PostDislikes = dislikes, PostCategories = postCategories, PostTags = postTags, UrlSlug = post.UrlSeo, PostVideos = postVideos });
            }
            return PartialView("Posts");

        }


        //Helper methods for the ability to call from the view
        #region Helpers
        public IList<Post> GetPosts()
        {
            return _blogRepository.GetPosts();
        }

        public IList<Category> GetPostCategories(Post post)
        {
            return _blogRepository.GetPostCategories(post);
        }

        public IList<Tag> GetPostTags(Post post)
        {
            return _blogRepository.GetPostTags(post);
        }

        public IList<PostVideo> GetPostVideos(Post post)
        {
            return _blogRepository.GetPostVideos(post);
        }



        #endregion
    }

    internal class ChildActionOnlyAttribute : Attribute
    {
    }
}
