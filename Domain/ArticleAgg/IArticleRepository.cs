using _01_FrameWork.Infrastructure;
using Application.Contracts.Article;

namespace Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        List<ArticleViewModel> GetList();
    }
}
