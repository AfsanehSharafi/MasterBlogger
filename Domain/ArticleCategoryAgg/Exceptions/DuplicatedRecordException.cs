﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ArticleCategoryAgg.Exceptions
{
    public class DuplicatedRecordException: Exception
    {
        public DuplicatedRecordException(string message):base(message)
        {
            
        }
    }
}
