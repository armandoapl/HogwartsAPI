using HogwartsRegistration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsRegistration.Interfaces
{
    public interface IRequestRepository
    {
        Task InsertAsync(InscriptionRequest request);
        Task UpdateAsync(InscriptionRequest updatedRequest);
        Task<IEnumerable<InscriptionRequest>> GetInscriptionsAsync();
        Task DeleteAsync(long hogwartsId);

    }
}
