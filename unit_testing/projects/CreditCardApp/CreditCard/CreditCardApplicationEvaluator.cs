using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCard
{
    public class CreditCardApplicationEvaluator
    {

        private readonly IFrequentFlyerNumberValidator _validator;
        private const int AutoReferralMaxAge = 20;
        private const int HighIncomeThreshold = 100_000;
        private const int LowIncomeThreshold = 20_000;

        public CreditCardApplicationEvaluator(IFrequentFlyerNumberValidator validator)
        {
            _validator = validator;

        }

        public CreditCardApplicationDecision Evaluate(CreditCardApplication application)
        {
            if(application.GrossAnnualIncome >= HighIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoAccepted;
            }

           var isValidFrequentFlyerNumber = _validator.IsValid(application.FrequentFlyerNumber);

            if (!isValidFrequentFlyerNumber)
            {
                return CreditCardApplicationDecision.ReferredToHuman;
            }
            if(application.Age <= AutoReferralMaxAge)
            {
                return CreditCardApplicationDecision.ReferredToHuman;
            }
            if(application.GrossAnnualIncome < LowIncomeThreshold)
            {
                return CreditCardApplicationDecision.AutoDeclined;
            }
            return CreditCardApplicationDecision.ReferredToHuman;
        }

    }
}
