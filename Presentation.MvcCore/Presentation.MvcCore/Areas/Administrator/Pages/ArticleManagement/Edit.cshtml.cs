using Application.Contracts.Article;
using Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcCore.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(long id)
        {
            Article = _articleApplication.Get(id);
            ArticleCategories = _articleCategoryApplication.list().Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(Article);
            return RedirectToPage("./List");
        }


    }
}
