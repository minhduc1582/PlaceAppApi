using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceApp.Places
{
    public class PlaceDto
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public StatusType Status { get; set; }
        public string PlaceType { get; set; }

    }
    //public class PlaceRequestReponseDto
    //{
    //    public string Name { get; set; }
    //    public string PlaceType { get; set; }
    //    public StatusType Status { get; set; }
    //}
    public class PlaceRequestReponseDto
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public StatusType Status { get; set; }  = StatusType.Pending;
        public string PlaceType { get; set; }
    }
}
