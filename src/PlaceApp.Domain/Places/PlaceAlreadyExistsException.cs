using Volo.Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceApp.Places
{
    public class PlaceAlreadyExistsException : BusinessException
    {
        public PlaceAlreadyExistsException(string name)
            : base(PlaceAppDomainErrorCodes.PlaceAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
