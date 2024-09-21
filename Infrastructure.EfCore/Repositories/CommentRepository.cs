using Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _content;
        public CommentRepository(MasterBloggerContext context)
        {
            _content = context;
        }
    }
}
