﻿using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITourniquetService
    {
        void Entry(Tourniquet tourniquet);
        void Exit(Tourniquet tourniquet);
    }
}