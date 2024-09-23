using _01_FrameWork.Infrastructure;
using Application.Contracts.ArticleCategory;
using Domain.ArticleCategoryAgg;
using Domain.ArticleCategoryAgg.Services;
using System.Globalization;

namespace Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _validatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository
            ,IArticleCategoryValidatorService validatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _validatorService = validatorService;
            _unitOfWork = unitOfWork;
        }

        public void Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Title, _validatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }


        public List<ArticleCategoryViewModel> list()
        {
            var articleCategories = _articleCategoryRepository.GetList();
            return (from articleCategory in articleCategories
                    select new ArticleCategoryViewModel
                    {
                        Id = articleCategory.Id,
                        Title = articleCategory.Title,
                        IsDeleted = articleCategory.IsDeleted,
                        CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture),
                    }).OrderByDescending(x=>x.Id).ToList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }



        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _unitOfWork.CommitTran();
        }


    }
}
