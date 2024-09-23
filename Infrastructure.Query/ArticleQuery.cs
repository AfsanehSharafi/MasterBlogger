
using Domain.CommentAgg;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    Image = x.Image,
                    Content = x.Content,
                    CommentCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                    Comments = MapComments(x.Comments.Where(z=> z.Status == Statuses.Confirmed)),
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return (from comment in comments
                    select new CommentQueryView
                    {
                        Name = comment.Name,
                        CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                        Message = comment.Message,


                    }).ToList();

        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    Image = x.Image,
                    CommentCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),

                }).ToList();
        }
    }
}
