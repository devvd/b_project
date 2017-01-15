using b_project.Data;
using b_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace b_project.DAL
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        //Get all posts
        public IList<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        //Get categories that are assigned to the post
        //Get category Ids from PostCategory table
        //Create an empty list of categories 
        //For each id in the categoryids list, get Category from the Category table and add it to the empty list, then return that list
        public IList<Category> GetPostCategories(Post post)
        {
            var categoryIds = _context.PostCategories.Where(p => p.PostId == post.Id).Select(p => p.CategoryId).ToList();
            List<Category> categories = new List<Category>();
            foreach (var catId in categoryIds)
            {
                categories.Add(_context.Categories.Where(p => p.Id == catId).FirstOrDefault());
            }
            return categories;
        }

        //Same operations and goal as above
        public IList<Tag> GetPostTags(Post post)
        {
            var tagIds = _context.PostTags.Where(p => p.PostId == post.Id).Select(p => p.TagId).ToList();
            List<Tag> tags = new List<Tag>();
            foreach (var tagId in tagIds)
            {
                tags.Add(_context.Tags.Where(p => p.Id == tagId).FirstOrDefault());
            }
            return tags;
        }

        //Since there isn't a separate table for videos we get the url's from the PostVideo table
        public IList<PostVideo> GetPostVideos(Post post)
        {
            var postUrls = _context.PostVideos.Where(p => p.PostId == post.Id).ToList();
            List<PostVideo> videos = new List<PostVideo>();
            foreach (var url in postUrls)
            {
                videos.Add(url);
            }
            return videos;
        }

        //Gets how many likes or dislikes a post, comment, or a reply has
        public int LikeDislikeCount(string typeandlike, string id)
        {
            switch (typeandlike)
            {
                case "postlike":
                    return _context.PostLikes.Where(p => p.PostId == id && p.Like == true).Count();
                case "postdislike":
                    return _context.PostLikes.Where(p => p.PostId == id && p.Dislike == true).Count();
                case "commentlike":
                    return _context.CommentLikes.Where(p => p.CommentId == id && p.Like == true).Count();
                case "commentdislike":
                    return _context.CommentLikes.Where(p => p.CommentId == id && p.Dislike == true).Count();
                case "replylike":
                    return _context.ReplyLikes.Where(p => p.ReplyId == id && p.Like == true).Count();
                case "replydislike":
                    return _context.ReplyLikes.Where(p => p.ReplyId == id && p.Dislike == true).Count();
                default:
                    return 0;
            }
            
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BlogRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        public IList<Category> GetPostCategories()
        {
            throw new NotImplementedException();
        }

        public IList<Tag> GetPostTags()
        {
            throw new NotImplementedException();
        }

        public IList<PostVideo> GetPostVideos()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
