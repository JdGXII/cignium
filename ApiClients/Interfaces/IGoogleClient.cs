using Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClients.Interfaces
{
    public interface IGoogleClient
    {
        Task<List<GoogleResponse>> GetResults(List<string> queries);
    }
}
