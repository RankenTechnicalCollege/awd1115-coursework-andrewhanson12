using CH9.Models;

namespace CH9.Data.Services
{
    public interface ICommentsService
    {
        Task Add(Comment comment);
    }
}
