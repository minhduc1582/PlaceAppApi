using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceApp.Places
{
    public class PlaceTypeDto
    {
        private string typeName;
        public string Type { get; set; }
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value.Trim(); }
        }
    }
    public class PlaceTypeRequestDto
    {
        public string Type { get; set; }
        public string TypeName { get; set; }
    }
    public class PlaceTypeReponseDto 
    {
        public string Type { get; set; }
        public string TypeName { get; set; }
    }

}
