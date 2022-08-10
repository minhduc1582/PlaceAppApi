using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PlaceApp.Places
{
    public interface IPlaceRepository : IRepository<Place, Guid>
    {
        Task<string> FindByNameAsync(string name);

        Task<List<Place>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
        Task<List<Place>> GetListByStatusTypeAsync(
            StatusType statusType,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
