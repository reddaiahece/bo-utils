using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsUtils
{
    class InputError : Exception
    {
        internal InputError(string message)
            : base(message) {
        }
    }
}
