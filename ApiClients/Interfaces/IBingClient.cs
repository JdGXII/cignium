using Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClients.Interfaces
{
    public interface IBingClient
    {
        Task<List<BingResponse>> GetResults(List<string> queries);
    }
}
