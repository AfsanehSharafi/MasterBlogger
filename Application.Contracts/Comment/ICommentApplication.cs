﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetList();
        void Add(AddComment command);
        void Confirm(long id);
        void Canceled(long id);
            
    }
}
