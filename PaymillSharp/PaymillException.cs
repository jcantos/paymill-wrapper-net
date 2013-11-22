using System;

namespace PaymillSharp
{
    public class PaymillException : Exception
    {
        public PaymillException(string message)
            : base(message)
        {
        }
    }
}