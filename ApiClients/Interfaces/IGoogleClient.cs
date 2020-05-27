using Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Interfaces
{
    public interface IGoogleClient
    {
        Task<GoogleResponse> GetResults();
    }
}
