namespace Application.Contracts.Comment
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mesage { get; set; }
        public long ArticleId { get; set; }
    }
}
