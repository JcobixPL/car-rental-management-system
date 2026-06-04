using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalManagementSystem.Application.Common.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
