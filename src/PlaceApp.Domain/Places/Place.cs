using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PlaceApp.Places
{
    public class Place : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public StatusType Status { get;set; }
        public string PlaceType { get; set; }
        public Place(string name, string source, StatusType status, string placeType)
        {
            Name = name;
            Source = source;
            Status = status;
            PlaceType = placeType;
        }
    }
}
