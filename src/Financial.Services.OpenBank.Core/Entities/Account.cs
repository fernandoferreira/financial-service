using System;
using Financial.Services.OpenBank.Core.Base;

namespace Financial.Services.OpenBank.Core.Domain
{
    public class Account:EntityBase
    {
        
        public Guid UserId { get; set ; }

        public int AccountNumber { get; set; }

        public decimal Amount { get; set ; }

        public bool IsActive { get ; set; }

    }
}
