using b_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace b_project.Data
{
    public static class DbInitializer
    {
        public static void Initialize(this BlogDbContext context)
        {
            context.Database.Migrate();

            //Look for Posts.
            //return - Db has been seeded
            if (context.Posts.Any())
            {
                return;
            }

            var category = new Category[]
            {
            new Category { Id = "cat1", Name = "Lorem", UrlSeo = "Lorem", Description = "Lorem Category" },
            new Category { Id = "cat2", Name = "Duis", UrlSeo = "Duis", Description = "Duis Category" },
            new Category { Id = "cat3", Name = "Nulla", UrlSeo = "Nulla", Description = "Nulla Category" },
            new Category { Id = "cat4", Name = "Ipsum", UrlSeo = "Ipsum", Description = "Ipsum Category" }
            };
            foreach (Category s in category)
            {
                context.Categories.Add(s);
            }
            context.SaveChanges();


            var post = new Post[]
                {
            new Post { Id = "1", Title = "Lorem", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec dolor metus. Nullam risus nisi, posuere eget consequat ac, lacinia ac arcu. Nulla facilisi. Nunc nec tristique sem, eu pulvinar augue. Morbi at risus eget tortor pharetra cursus eu at ligula. Mauris eu commodo nisl, ac lobortis lectus. Ut rhoncus rutrum elit sed fringilla. Etiam in accumsan purus. Maecenas orci diam, consequat a tellus at, pellentesque ullamcorper elit. Sed quis consequat turpis. Proin lacinia est sit amet felis imperdiet, sit amet convallis nulla imperdiet. Nunc sit amet justo sapien. Nulla pulvinar mi quis dapibus commodo.", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec dolor metus. Nullam risus nisi, posuere eget consequat ac, lacinia ac arcu. Nulla facilisi. Nunc nec tristique sem, eu pulvinar augue. Morbi at risus eget tortor pharetra cursus eu at ligula.", PostedOn = DateTime.Now, Meta = "Lorem", UrlSeo = "Lorem", Published = true },

            new Post { Id = "2", Title = "duis", Body = "duis sed bibendum risus, nec porta velit. proin commodo lectus ut nibh blandit tincidunt ut non nibh. pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. aenean pretium, felis eget sollicitudin pharetra, arcu ante commodo eros, ut mattis lacus neque sed augue. fusce laoreet libero eros, sit amet iaculis mauris tempor sit amet. donec sollicitudin bibendum sem. nullam a ligula placerat velit rutrum finibus. vivamus dapibus diam vel nisi pellentesque, et iaculis tellus commodo. donec efficitur sapien eget arcu cursus bibendum. morbi risus risus, pellentesque ac sem a, tempor tristique elit.", ShortDescription = "duis sed bibendum risus, nec porta velit. proin commodo lectus ut nibh blandit tincidunt ut non nibh. pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.", PostedOn = DateTime.Now, Meta = "duis", UrlSeo = "duis", Published = true },


            new Post { Id = "3", Title = "nulla", Body = "nulla mattis mi in elementum elementum. aliquam dictum quam id nibh fermentum maximus. curabitur facilisis neque eget lorem scelerisque vestibulum. sed et pulvinar turpis, eu convallis urna. vivamus consectetur vel lorem ut dictum. aliquam ac ante eu tortor pharetra efficitur. fusce mattis lacinia arcu, vel dignissim leo fermentum ac. donec tincidunt pellentesque tristique. pellentesque porta faucibus scelerisque. ut ante mi, iaculis eleifend augue vel, fringilla sodales felis. pellentesque vehicula metus sapien, eget sagittis augue eleifend ut. ut sit amet nulla est. sed vel turpis quis dui lobortis accumsan a a mi. donec nec sagittis urna.", ShortDescription = "nulla mattis mi in elementum elementum. aliquam dictum quam id nibh fermentum maximus. curabitur facilisis neque eget lorem scelerisque vestibulum.", PostedOn = DateTime.Now, Meta = "nulla", UrlSeo = "nulla", Published = true }
            };
            foreach (Post s in post)
            {
                context.Posts.Add(s);
            }
            context.SaveChanges();


            var postcategories = new PostCategory[]
            {
            new PostCategory { PostId = "1", CategoryId = "cat1" },
            new PostCategory { PostId = "1", CategoryId = "cat4" },
            new PostCategory { PostId = "2", CategoryId = "cat2" },
            new PostCategory { PostId = "3", CategoryId = "cat3" }
            };
            foreach (PostCategory s in postcategories)
            {
                context.PostCategories.Add(s);
            }
            context.SaveChanges();


            var postvideo = new PostVideo[]
                {
            new PostVideo { Id = "1", PostId = "1", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/HcSEU_BZwDw", VideoThumbnail = "http://img.youtube.com/vi/HcSEU_BZwDw/0.jpg" },
            new PostVideo { Id = "2", PostId = "2", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/HcSEU_BZwDw", VideoThumbnail = "http://img.youtube.com/vi/HcSEU_BZwDw/0.jpg" },
            new PostVideo { Id = "3", PostId = "3", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/HcSEU_BZwDw", VideoThumbnail = "http://img.youtube.com/vi/HcSEU_BZwDw/0.jpg" },
            new PostVideo { Id = "4", PostId = "1", VideoSiteName = "YouTube", VideoUrl = "https://www.youtube.com/embed/XzAHGhMhl7o", VideoThumbnail = "http://img.youtube.com/vi/XzAHGhMhl7o/0.jpg" }
                };
            foreach (PostVideo s in postvideo)
            {
                context.PostVideos.Add(s);
            }
            context.SaveChanges();


            var comment = new Comment[]
                {
            new Comment { Id = "cmt1", PostId = "1", Body = "Vivamus hendrerit commodo pulvinar. In convallis nunc nec scelerisque sodales. Curabitur aliquam neque dolor, hendrerit cursus felis ultricies ac. Mauris ac justo vel lorem condimentum malesuada. Vivamus porttitor vestibulum lorem a luctus. Suspendisse in eleifend orci.", DateTime = DateTime.Now, UserName = "devsone" },
            new Comment { Id = "cmt2", PostId = "1", Body = "Suspendisse egestas risus eget posuere egestas. Nunc facilisis ligula et vestibulum pretium. Suspendisse potenti. Nulla facilisi. Integer mi lorem, efficitur quis viverra in, sollicitudin id urna. Maecenas scelerisque, tellus eget rutrum pulvinar, velit erat pulvinar risus, vitae convallis quam mi ut leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Ut posuere lacus ex, eget tristique quam eleifend molestie.", DateTime = DateTime.Now, UserName = "mario" },
            new Comment { Id = "cmt3", PostId = "1", Body = "Integer lacinia ipsum magna, ac sodales libero porttitor at. Donec at enim felis. Ut bibendum lorem odio, quis ultricies elit eleifend ut. Fusce erat tellus, eleifend at gravida in, fermentum et tellus. Fusce at massa vehicula, maximus diam nec, lacinia lectus.", DateTime = DateTime.Now, UserName = "natash" }
                };
            foreach (Comment s in comment)
            {
                context.Comments.Add(s);
            }
            context.SaveChanges();


            var reply = new Reply[]
                {
            new Reply { Id = "rep1", PostId = "1", CommentId = "cmt3", DateTime = DateTime.Now, UserName = "flint", Body = "Cras sodales justo sit amet libero placerat consectetur. Duis hendrerit facilisis tempor. Nullam ut nisl nec neque posuere semper. Praesent vestibulum id purus quis maximus." },
            new Reply { Id = "rep9", PostId = "1", CommentId = "cmt3", DateTime = DateTime.Now, UserName = "anyav", Body = "Cras sodales justo sit amet libero placerat consectetur. Duis hendrerit facilisis tempor. Nullam ut nisl nec neque posuere semper. Praesent vestibulum id purus quis maximus." },
            new Reply { Id = "rep2", PostId = "1", CommentId = "cmt3", ParentReplyId = "rep1", DateTime = DateTime.Now, UserName = "devsone", Body = "Mauris pulvinar tristique libero id ornare. Quisque sit amet accumsan leo. Vestibulum dapibus elit sed lorem lacinia suscipit. In hac habitasse platea dictumst. Vivamus egestas leo eu nulla faucibus cursus." },
            new Reply { Id = "rep3", PostId = "1", CommentId = "cmt3", ParentReplyId = "rep2", DateTime = DateTime.Now, UserName = "kingkong", Body = "Suspendisse consequat dolor urna, sit amet accumsan lectus luctus eget. Vestibulum maximus ante vel placerat cursus. Nulla luctus augue ac vulputate aliquet." },
            new Reply { Id = "rep4", PostId = "1", CommentId = "cmt3", ParentReplyId = "rep3", DateTime = DateTime.Now, UserName = "hanley", Body = "Donec aliquam, sem a tincidunt tincidunt, orci velit mollis magna, vel auctor arcu augue nec risus. Integer luctus enim ac viverra luctus." },
            new Reply { Id = "rep5", PostId = "1", CommentId = "cmt2", DateTime = DateTime.Now, UserName = "taylor", Body = "Cras sodales justo sit amet libero placerat consectetur. Duis hendrerit facilisis tempor. Nullam ut nisl nec neque posuere semper. Praesent vestibulum id purus quis maximus." },
            new Reply { Id = "rep6", PostId = "1", CommentId = "cmt2", ParentReplyId = "rep5", DateTime = DateTime.Now, UserName = "devsone", Body = "Mauris pulvinar tristique libero id ornare. Quisque sit amet accumsan leo. Vestibulum dapibus elit sed lorem lacinia suscipit." },
            new Reply { Id = "rep7", PostId = "1", CommentId = "cmt2", ParentReplyId = "rep6", DateTime = DateTime.Now, UserName = "hanley", Body = "Suspendisse consequat dolor urna, sit amet accumsan lectus luctus eget. Vestibulum maximus ante vel placerat cursus. Nulla luctus augue ac vulputate aliquet." },
            new Reply { Id = "rep8", PostId = "1", CommentId = "cmt2", ParentReplyId = "rep7", DateTime = DateTime.Now, UserName = "taylor", Body = "Donec aliquam, sem a tincidunt tincidunt, orci velit mollis magna, vel auctor arcu augue nec risus. Integer luctus enim ac viverra luctus." }
                };
            foreach (Reply s in reply)
            {
                context.Replies.Add(s);
            }
            context.SaveChanges();

        }
    }
}