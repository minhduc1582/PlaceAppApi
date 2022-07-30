using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PlaceApp.Places
{
    public interface IPlaceRepository : IRepository<Place, Guid>
    {
        Task<List<Place>> GetListAsync(

            string filter = null
        );
        Task<Place> FindByName(string name);
    }
}
