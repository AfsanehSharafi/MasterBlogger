﻿using _01_FrameWork.Domain;
using Domain.ArticleAgg;
using Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }

        public ICollection<Article> Articles { get; private set; }
        protected ArticleCategory()
        {
            
        }
        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GuardAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);
            Title =title;
            IsDeleted = false;
            Articles= new List<Article>();
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
