﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite.Scaffolder.Exceptions
{
    public class MultipleColumnsWithSameNameException : Exception
    {
        public MultipleColumnsWithSameNameException(string message) : base(message) { }
    }
}
