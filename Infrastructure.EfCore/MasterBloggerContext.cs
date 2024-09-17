using Domain.ArticleCategoryAgg;
using Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore
{
    public class MasterBloggerContext:DbContext
    {
        public DbSet<ArticleCategory> articleCategories {  get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
