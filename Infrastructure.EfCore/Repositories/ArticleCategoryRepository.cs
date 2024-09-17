using Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }
        public void Add(ArticleCategory entity)
        {
            _context.articleCategories.Add(entity);
            Save();
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.articleCategories.OrderByDescending(x=>x.Id).ToList();
        }


        public ArticleCategory Get(long id)
        {
            return _context.articleCategories.FirstOrDefault(X => X.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _context.articleCategories.Any(x => x.Title == title);
        }
    }
}
