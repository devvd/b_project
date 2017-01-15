using b_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace b_project.DAL
{
    //Here I am adding definitions of the methods to the interface
    public interface IBlogRepository : IDisposable
    {
        IList<Post> GetPosts();
        IList<Category> GetPostCategories(Post post);
        IList<Tag> GetPostTags(Post post);
        IList<PostVideo> GetPostVideos(Post post);
        int LikeDislikeCount(string typeandlike, string id);
    }
}
