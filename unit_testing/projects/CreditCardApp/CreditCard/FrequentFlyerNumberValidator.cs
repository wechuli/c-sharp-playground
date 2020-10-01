using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCard
{
    public class FrequentFlyerNumberValidator : IFrequentFlyerNumberValidator
    {

       /// <summary>
       /// Contacts an external service to validate a frequent flyer number
       /// Some of the reasons we may want to mock this external service could include:
       ///    Cost
       ///    Slow
       ///    No test version
       ///    Unreliable
       ///    Effor
       /// </summary>
       public  bool  IsValid(string frequentlyFlyerNumber)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }

        public void IsValid(string frequentFlyerNumber, out bool isValid)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }
    }
}
