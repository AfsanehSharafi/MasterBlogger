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
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _content;
        public CommentRepository(MasterBloggerContext context)
        {
            _content = context;
        }

        public void CreateAndSave(Comment Entity)
        {
            _content.Comments.Add(Entity);
            _content.SaveChanges();
        }

        public List<CommentViewModel> GetList()
        {
            return _content.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article=x.Article.Title
            }).ToList();
        }
    }
}
