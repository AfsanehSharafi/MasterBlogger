using _01_FrameWork.Infrastructure;
using Application;
using Application.Contracts.Article;
using Application.Contracts.ArticleCategory;
using Application.Contracts.Comment;
using Domain.ArticleAgg;
using Domain.ArticleAgg.Services;
using Domain.ArticleCategoryAgg;
using Domain.ArticleCategoryAgg.Services;
using Domain.CommentAgg;
using Infrastructure.EfCore;
using Infrastructure.EfCore.Repositories;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Core
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

            services.AddTransient<ICommentApplication, CommentAplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IUnitOfWork,UnitOfWorkEf>();

            services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(ConnectionString));


        }


    }
}
