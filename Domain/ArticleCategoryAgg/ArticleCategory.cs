using Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);
            Title =title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }


        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title =title;
        }

        public void Remove()
        { 
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted=false;
        }
    }
}
