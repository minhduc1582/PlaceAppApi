using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PlaceApp.Places
{
    public interface IPlaceTypeRepository : IRepository<PlaceType, Guid>
    {
        Task<List<PlaceType>> GetListAsync(

            string filter = null
        );
        Task<PlaceType> FindByName(string name);
    }
}
