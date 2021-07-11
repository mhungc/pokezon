using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Domain.Types
{
    public enum OrderStatus
    {
        Cancel,
        Pending,
        Approved
    }

    public enum OrderPayment
    {
        CreditCard,
        PayPal,
        BankTransfer
    }
}

