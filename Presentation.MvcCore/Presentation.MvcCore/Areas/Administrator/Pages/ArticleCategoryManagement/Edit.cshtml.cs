using Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MvcCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RenameArticleCategory ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(long id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}

