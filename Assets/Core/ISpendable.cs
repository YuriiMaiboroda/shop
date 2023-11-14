using System;
using System.Collections.Generic;

namespace Core
{
    public interface ISpendable {
        bool CanSpend();
        bool CanSpend(IEnumerable<ISpendable> neighbours);
        void Spend();

        event Action CurrencyAmountChanged;
    }
}

