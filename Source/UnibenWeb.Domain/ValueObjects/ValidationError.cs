using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.ValueObjects
{
    public class ValidationError
    {
        public string Message { get; set; }

        public ValidationError(string message)
        {
            this.Message = message;
        }
    }
}
