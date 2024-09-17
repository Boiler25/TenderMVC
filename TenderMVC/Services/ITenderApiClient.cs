using TenderMVC.Models;

namespace TenderMVC.Services
{
    public interface ITenderApiClient
    {
        Task<IEnumerable<TenderViewModel>> GetTendersAsync();
    }
}
