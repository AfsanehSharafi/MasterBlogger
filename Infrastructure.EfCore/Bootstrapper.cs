using Application;
using Application.Contracts.Article;
using Application.Contracts.ArticleCategory;
using Domain.ArticleAgg;
using Domain.ArticleCategoryAgg;
using Domain.ArticleCategoryAgg.Services;
using Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleApplication,ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(ConnectionString));


        }


    }
}
