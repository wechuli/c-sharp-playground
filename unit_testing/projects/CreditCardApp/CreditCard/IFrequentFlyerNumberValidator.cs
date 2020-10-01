using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCard
{
    public interface IFrequentFlyerNumberValidator
    {
        bool IsValid(string frequentlyFlyerNumber);
        void IsValid(string frequentFlyerNumber, out bool isValid);

    }
}
