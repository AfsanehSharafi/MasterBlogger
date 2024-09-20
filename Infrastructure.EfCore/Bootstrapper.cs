using Application;
using Application.Contracts.Article;
using Application.Contracts.ArticleCategory;
using Domain.ArticleAgg;
using Domain.ArticleAgg.Services;
using Domain.ArticleCategoryAgg;
using Domain.ArticleCategoryAgg.Services;
using Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.EfCore
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();


            services.AddTransient<IArticleApplication,ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(ConnectionString));


        }


    }
}
