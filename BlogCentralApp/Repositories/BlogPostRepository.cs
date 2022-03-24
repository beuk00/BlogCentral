
using BlogCentralApp.Data;
using BlogCentralLib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>
    {
        public BlogPostRepository(DataContext ctx) : base(ctx)
        {

        }

        public override async Task<BlogPost> GetById<P>(P id)
        {
            return await _dbContext.BlogPosts.Include(a=>a.Author).Include(b => b.Comments).ThenInclude(c => c.Author).Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Like(int id)
        {
            
            BlogPost blogPost = await GetById(id);
            blogPost.Likes++;
            await Update(blogPost);
        }
        public async Task Unlike(int id)
        {

            BlogPost blogPost = await GetById(id);
            blogPost.Likes =blogPost.Likes-1;
            await Update(blogPost);
        }
        public override async Task<IEnumerable<BlogPost>> ListAll()
        {
            return await _dbContext.BlogPosts.Include(b => b.Author).ToListAsync();
        }

        public List<BlogPost> SearchAsync(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                searchString = "";
            }
            searchString = searchString.ToLower();
            List<BlogPost> allBlogPosts =  _dbContext.BlogPosts.Include(b => b.Author).ToList();
            List<BlogPost> searchedBlogPosts = new List<BlogPost>();

            foreach (var blogPost in allBlogPosts)
            {
                string tepmTitle = blogPost.Title;
                blogPost.Title = blogPost.Title.ToLower();
                if (!String.IsNullOrEmpty(searchString) && blogPost.Title.Contains(searchString))
                {
                    blogPost.Title = tepmTitle;
                    searchedBlogPosts.Add(blogPost);
                }
            }
            foreach (var blogPost in allBlogPosts)
            {
                string tepmAuthor = blogPost.Author.UserName;
                blogPost.Author.UserName = blogPost.Author.UserName.ToLower();
                if (!String.IsNullOrEmpty(searchString) && blogPost.Author.UserName.Contains(searchString))
                {
                    blogPost.Author.UserName = tepmAuthor;
                    searchedBlogPosts.Add(blogPost);
                }
            }

            var uniqueItems = searchedBlogPosts.Distinct().ToList();

            return uniqueItems;
        }

    }
}
