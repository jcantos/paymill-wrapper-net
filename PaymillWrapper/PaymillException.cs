using System;

namespace PaymillWrapper
{
    public class PaymillException : Exception
    {
        public PaymillException(string message)
            : base(message)
        {
        }
    }
}