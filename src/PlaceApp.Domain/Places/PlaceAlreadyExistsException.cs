﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace PlaceApp.Places
{
    public class PlaceAlreadyExistsException : BusinessException
    {
        public PlaceAlreadyExistsException(string name)
            : base(PlaceAppDomainErrorCodes.AlreadyExists)
        {
            WithData("name", name);
        }
    }
}
