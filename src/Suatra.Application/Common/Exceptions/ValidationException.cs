using Suatra.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suatra.Application.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(Result validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error);
            }
        }
    }
}
