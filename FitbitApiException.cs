using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitbitApiClient
{
    public class FitbitApiException : Exception
    {
        public FitbitApiException() { }

        public FitbitApiException(string message)
            : base(message) { }

        public FitbitApiException(string message, Exception inner)
            : base(message, inner) { }
    }
}
