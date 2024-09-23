using _01_FrameWork.Infrastructure;
using Application.Contracts.Comment;
using Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore.Repositories
{
    public class CommentRepository: BaseRepository<long,Comment> ,ICommentRepository
    {
        private MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }



        List<CommentViewModel> ICommentRepository.GetList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title
            }).ToList();
        }
    }
}
