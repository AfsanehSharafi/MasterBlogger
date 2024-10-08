﻿using _01_FrameWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string title);
    }

    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleRepository.Exists(x=> x.Title == title)) 
            {
                throw new DuplicateWaitObjectException();
            }
        }
    }
}
