using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> list();
        void Create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory Get(long id);
        void Remove(long id);
        void Activate (long id);
    }
}
