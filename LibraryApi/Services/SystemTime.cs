﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent => DateTime.Now;
    }
}
