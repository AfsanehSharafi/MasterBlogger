﻿using Application.Contracts.Comment;
using Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CommentAplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        public CommentAplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
    }
}
