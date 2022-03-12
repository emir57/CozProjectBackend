﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; }
    }
}
