using _01_FrameWork.Infrastructure;
using Application.Contracts.Comment;

namespace Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> GetList();
    }
}
