using System.Collections.Generic;
using System.Threading.Tasks;
using ClientDNP.Models;

namespace ClientDNP.Data
{
    internal interface IAdultData
    {
        Task Add(Adult adult);
        Task<IList<Adult>> GetAdults();

        Task RemoveAdult(Adult adult);
        Adult Get(int id);
    }
}