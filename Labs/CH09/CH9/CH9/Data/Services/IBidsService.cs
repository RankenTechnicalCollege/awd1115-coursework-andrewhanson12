using CH9.Models;

namespace CH9.Data.Services
{
    public interface IBidsService
    {
        Task Add(Bid bid);
    }
}
