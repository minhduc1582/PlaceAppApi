using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PlaceApp.Places
{
    public class PlaceType : AuditedAggregateRoot<Guid>
    {
        public string Type { get; set; }
        public string TypeName { get; set; }
        public Guid GroupId { get; set; }
    }
}
